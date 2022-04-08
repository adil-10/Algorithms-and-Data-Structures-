using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_B_2
{
    public partial class Form1 : Form
    {
        LinkListGen<Book> myList = new LinkListGen<Book>();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {         
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            { 
                MessageBox.Show("Please enter the correct information"); 
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))                
            {
                MessageBox.Show("Please enter only numbers.");
                textBox3.Text = textBox3.Text.Remove(textBox1.Text.Length - 1);
            }
            else  
            {
                
                myList.InsertInOrder(new Book() { Author = new Person(textBox1.Text), Title = textBox2.Text, Pubyear = new pubyear(int.Parse(textBox3.Text)) });
                

                listBox1.Items.Add(myList.DisplayList());
                
                label5.Text = myList.Count().ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //myList.RemoveItem();
            //listBox1.Items.RemoveAt(new Book(textBox4.Text));
            //foreach (var item in myList())
            //{
            //    myList.RemoveItem(item);
            //}
            label5.Text = myList.Count().ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Text = "";
        }


    }
}
