using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] id = {1,
                2,
                3,
                4,
                5,
                6,7,8,9,10};
            string[] stuName = { "Maguire", "Kolling", "Bentley", "Sierra", "Richie", "Brooks", "Knuth", "McConnal", "Gamma", "Weiss" };
            

            Student[] library = new Student[10];


            // create an array of books
            for (int i = 0; i < library.Length; i++)
            {
                library[i] = new Student(id[i], stuName[i]);

            }


            // call selection sort on an array of book
            InsertSortGen(library);


            // display array of book after sorting

            for (int i = 0; i < library.Length; i++)
            {
                Console.WriteLine(library[i].GetSummary());

            }
            Console.ReadKey();
        }
        static public void InsertSortGen<T>(T[] a) where T : IComparable
        {
            for (int i = 1; i < a.Length; i++)
            {
                T value = a[i];
                int j = i;

                for (; j > 0 && a[j - 1].CompareTo(value) > 0; j--)
                {
                    a[j] = a[j - 1];
                }
                a[j] = value;
            }
        }
    }
}
