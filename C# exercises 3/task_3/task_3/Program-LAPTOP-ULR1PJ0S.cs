using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            BSTree<string> mytree = new BSTree<string>();

            mytree.InsertItem("dil");
            mytree.InsertItem("nekjd2ew");
            mytree.InsertItem("nekjd");
            mytree.HeightRecursive();
            mytree.CountRecursive();
            string s = "";
            mytree.InOrder(ref s);
            Console.WriteLine(s);

            Console.WriteLine(mytree.HeightRecursive());
            Console.WriteLine(mytree.CountRecursive());

            //Console.WriteLine(mytree.readFile());
            Console.ReadKey();

        }

        static void readFile(string fileName)
        {
            const int MAX_FILE_LINES = 50000;
            string[] AllLines = new string[MAX_FILE_LINES];

            //reads from bin/DEBUG subdirectory of project directory
            AllLines = File.ReadAllLines(fileName);


            foreach (string line in AllLines)
            {
                //split words using space , . ?
                string[] words = line.Split(' ', ',', '.', '?', ';', ':', '!');
                foreach (string word in words)
                    if (word != "")
                        Console.WriteLine(word.ToLower());
                
            }

        }


    }
}
