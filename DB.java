package uk.ac.mmu.advprog.hackathon;
import org.json.*;

import java.awt.datatransfer.Transferable;
import java.io.StringWriter;
import java.io.Writer;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import javax.xml.crypto.dsig.Transform;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.transform.OutputKeys;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;

import org.json.JSONArray;
import org.json.JSONObject;
import org.json.XML;
import org.w3c.dom.Document;
import org.w3c.dom.Element;

/**
 * Handles database access from within your web service
 * @author You, Mainly!
 */
public class DB implements AutoCloseable {
	
	//allows us to easily change the database used
	private static final String JDBC_CONNECTION_STRING = "jdbc:sqlite:./data/AMI.db";
	
	//allows us to re-use the connection between queries if desired
	private Connection connection = null;
	
	/**
	 * Creates an instance of the DB object and connects to the database
	 */
	public DB() {
		try {
			connection = DriverManager.getConnection(JDBC_CONNECTION_STRING);
		}
		catch (SQLException sqle) {
			error(sqle);
		}
	}
	
	/**
	 * Returns the number of entries in the database, by counting rows
	 * @return The number of entries in the database, or -1 if empty
	 */
	
	
	public int getNumberOfEntries() {
		int result = -1;
		try {
			Statement s = connection.createStatement();
			ResultSet results = s.executeQuery("SELECT COUNT(*) AS count FROM ami_data");
			while(results.next()) { //will only execute once, because SELECT COUNT(*) returns just 1 number
				result = results.getInt(results.findColumn("count"));
			}
		}
		catch (SQLException sqle) {
			error(sqle);
			
		}
		return result;
	}
	
	//task1
	
	//Searching through database to find certain value depednig on local host url(postcode)
	/**
	 * 
	 * @param id which specifies the postcode
	 * @return returns id of last signal prior to it being turned off
	 */
	public String lastsignal(String id)
	{
		String a = "";
		PreparedStatement s;
		try {
			//connection to make query and storing data into  variable
			s = connection.prepareStatement("SELECT signal_value FROM ami_data WHERE signal_id = ? AND NOT signal_value = \"OFF\" AND NOT signal_value = \"NR\" AND NOT signal_value = \"BLNK\" ORDER BY datetime DESC LIMIT 1;");
			s.setString(1, id);
			ResultSet statement = s.executeQuery();
			a = statement.getString("signal_value");
		}
		catch (SQLException e) {
			e.printStackTrace();
			
		}
	//return output
		return  a;
		
	}
	
	//task2
	/**
	 * 
	 * @param frequency
	 * @returns generates a json array format indicating the frequency of how many occurances the signal value had
	 */
	public String frequency(String frequency)
	{
		//create json array
		JSONArray root = new JSONArray ();
		PreparedStatement s;
		//connection to DB for sql query and executig query
		try {
			s = connection.prepareStatement("SELECT COUNT(signal_value) AS frequency, signal_value FROM ami_data WHERE signal_id LIKE ? GROUP BY signal_value ORDER BY frequency DESC");
			s.setString(1, frequency+ "%");
			ResultSet rs = s.executeQuery();

			
			while (rs.next())
			{
				//create json object, add values to jason object and then root for executing later.
				JSONObject jsonObject = new JSONObject();
				jsonObject.put("value",rs.getString("signal_value"));
				jsonObject.put("frequency",rs.getString("frequency"));
				root.put(jsonObject);
				
			}
			
		}
		catch (SQLException e) {
			e.printStackTrace();
			
		}
		//return what is contained inside of root in a json array format
		return root.toString();
	}
	
	//task3
	/**
	 * 
	 * @returns in an xml format the signal groups 
	 */
	public String signalsGroup()
	{
		
		try {
			//sql query
			PreparedStatement s;
			s = connection.prepareStatement("SELECT DISTINCT signal_group FROM ami_data;");
			ResultSet rs = s.executeQuery();
			
			//building tree
			DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
			Document doc = dbf.newDocumentBuilder().newDocument();
			
			//creating element Groups
			Element signal = doc.createElement("Groups");
			//append signal into doc
			doc.appendChild(signal);
			String temp = "";
			while(rs.next())
			{
				// adding data in group into group1, then group 1 into signal
				temp = rs.getString("signal_group");
				Element group1 = doc.createElement("group");
				group1.setTextContent(temp);
				signal.appendChild(group1);
			}
			//get xml into string and our put result
			Transformer transformer = TransformerFactory.newInstance().newTransformer();
			Writer output = new StringWriter();
			transformer.setOutputProperty(OutputKeys.INDENT,"yes");
			transformer.transform(new DOMSource(doc), new StreamResult(output));
			return output.toString();
			
		}
		catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		//return null;
		return null;
		
	}
	
	/**
	 * Closes the connection to the database, required by AutoCloseable interface.
	 */
	@Override
	public void close() {
		try {
			if ( !connection.isClosed() ) {
				connection.close();
			}
		}
		catch(SQLException sqle) {
			error(sqle);
		}
	}
	

	/**
	 * Prints out the details of the SQL error that has occurred, and exits the programme
	 * @param sqle Exception representing the error that occurred
	 */
	private void error(SQLException sqle) {
		System.err.println("Problem Opening Database! " + sqle.getClass().getName());
		sqle.printStackTrace();
		System.exit(1);
	}
}
