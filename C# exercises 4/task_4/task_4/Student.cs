using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4
{
    class Student : IComparable
    {

        private int id;
        private string stuName;


        public Student(int id, string stuName) //constructor with one argument
        {
            this.id = id;
            this.stuName = stuName;
        }



        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string StuName
        {
            get { return stuName; }
            set { stuName = value; }
        }

        public int CompareTo(Object obj) //implementation of CompareTo
        {                   // 		for IComparable

            Student other = (Student)obj;
            return stuName.CompareTo(other.stuName);
        }
        public string GetSummary()
        {
            string bookSummary = "ID:" + ID + " " + "Name:" + stuName;
            return bookSummary;

        }
    }
}
