using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_5_B
{

    public partial class Form1 : Form

    {
        private Graph<string> myGraph;
        public Form1()
        {
            InitializeComponent();
            myGraph = new Graph<string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myGraph.AddNode(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myGraph.AddEdge((textBox2.Text), (textBox3.Text));
        }
    }
}
