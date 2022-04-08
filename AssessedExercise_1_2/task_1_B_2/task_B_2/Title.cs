using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_B_2
{
    class Title : IComparable
    {
        private string title;

        public Title(string title) //constructor with one argument
        {
            this.title = title;
        }

        public string NewTitle
        {
            get { return title; }
            set { title = value; }
        }

        public int CompareTo(Object obj) //implementation of CompareTo
        {                   // 		for IComparable

            Title other = (Title)obj;
            return NewTitle.CompareTo(other.NewTitle);
        }
        public override string ToString()
        {
            return NewTitle.ToString();
        }
    }
}
