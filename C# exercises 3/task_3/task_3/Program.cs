using System;
using System.IO;


namespace task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            readFile("textFile.txt");
            Console.ReadKey();
        }
            static void readFile(string fileName)
        {
            BSTree<string> mytree = new BSTree<string>();
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
                    {
                        Console.WriteLine(word.ToLower());
                            mytree.InsertItem(word.ToLower());

                    }

            }
            mytree.HeightRecursive();
            mytree.CountRecursive();
            Console.WriteLine(mytree.HeightRecursive());
            Console.WriteLine(mytree.CountRecursive());
        }
    }
}
