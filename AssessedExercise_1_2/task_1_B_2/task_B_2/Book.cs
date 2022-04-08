using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_B_2
{
    class Book : IComparable
    {
        private Person author;
        private string title_journal;
        private string title;
        private pubyear pub_year;

        public Book()
        {
        }

        public Book(string title_journal) //constructor with one argument
        {
            this.title_journal = title_journal;
        }

        public Book(Title title) //constructor with one argument
        {
            this.title = Title;
        }

        public Book(Person author)
        {
            this.author = author;
        }

        public Book(pubyear pub_year)
        {
            this.pub_year = pub_year;
        }

        public string Title_Journal
        {
            get { return title_journal; }
            set { title_journal = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public Person Author
        {
            get { return author; }
            set { author = value; }
        }
        public pubyear Pubyear
        {
            get { return pub_year; }
            set { pub_year = value; }
        }

        public int CompareTo(Object obj) //implementation of CompareTo
        {                   // 		for IComparable

            Book other = (Book)obj;
            return Author.CompareTo(other.Author);
        }
        public override string ToString()
        {

            return author + " " + title_journal + " " + title + " " + pub_year +"\n";
        }
    }
}

