using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ask how to do is empty and is full mehtod
// ask how to implement it 


namespace task_A
{
    public partial class Form1 : Form
    {
        Queue<string> myQueue = new Queue<string>();
        public Form1()
        {  
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            count.Text = ("Initial number of elements: ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //use is full method here

           // myQueue.IsFull();
            

            if (textBox1.Text == (""))
            {
                MessageBox.Show("please enter text");
            }
            else
            {
                // adds what user inputs to queue
                myQueue.Enqueue(textBox1.Text);

                // if label is empty adds text from textbox, if full it doesnt display text
                if (label1.Text == "")
                { label1.Text = textBox1.Text; }
                else
                {

                }

                //counter
                count.Text = ("Initial number of elements: " + myQueue.Count);
                textBox1.Clear();  
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dequeue the top of the queue
            myQueue.Dequeue();
            // dsplays how many elements are in queue
            count.Text = ("Initial number of elements: " + myQueue.Count);
            //checks if queue is empty is so label has no text
            //use isempty method here 
            if (myQueue == null)
            label1.Text = "";
            
            else
            {
                //displays the {0} point of the queue after a dequeue
                label1.Text = (myQueue.Peek());

            }
        }

    }
}
    
    

