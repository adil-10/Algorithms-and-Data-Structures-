using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_B_2
{
    class Person : IComparable
    {
        private string name;

        public Person(string name) //constructor with one argument
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int CompareTo(Object obj) //implementation of CompareTo
        {                   // 		for IComparable

            Person other = (Person)obj;
            return Name.CompareTo(other.Name);
        }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
