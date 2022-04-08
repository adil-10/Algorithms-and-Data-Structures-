using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_5
{
    public partial class Form1 : Form
    {
        private Graph<int> myGraph;
        //Graph<string> myGraph = new Graph<string>();
        public Form1()
        {
            InitializeComponent();
            myGraph = new Graph<int>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // add nodes in the graph
            //myGraph.AddNode(int.Parse(textBox1.Text));
            myGraph.AddNode((int.Parse(textBox1.Text)));
            label4.Text = myGraph.NumNodesGraph().ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            myGraph.AddEdge((Convert.ToInt32(textBox2.Text)), (Convert.ToInt32(textBox3.Text)));
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (myGraph.IsAdjacent(myGraph.GetNodeByID(Convert.ToInt32(textBox4.Text)), myGraph.GetNodeByID(Convert.ToInt32(textBox5.Text))) == true)
            {
                label5.Text = "true";
            }
            else if (myGraph.IsAdjacent(myGraph.GetNodeByID(Convert.ToInt32(textBox4.Text)), myGraph.GetNodeByID(Convert.ToInt32(textBox5.Text))) == false)
            {
                label5.Text = "false";
            }

        }
    }
}
