using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_B_2
{
    class pubyear : IComparable
    {
        private int pub_year;
        private string text;

        public pubyear(int pub_year) //constructor with one argument
        {
            this.pub_year = pub_year;
        }

        public pubyear(string text)
        {
            this.text = text;
        }

        public int Pub_Year
        {
            get { return pub_year; }
            set { pub_year = value; }
        }

        public int CompareTo(Object obj) //implementation of CompareTo
        {                   // 		for IComparable

            pubyear other = (pubyear)obj;
            return Pub_Year.CompareTo(other.Pub_Year);
        }

        public override string ToString()
        {
            return pub_year.ToString();
        }
    }
}

