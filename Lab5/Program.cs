using System;
using System.IO;

namespace Lab5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Magazine magazine1 = new Magazine();
            Magazine magazine2 = (Magazine) magazine1.DeepCopy();
            
            Console.WriteLine("Original is \n{0} \nCopy is \n {1}", magazine1, magazine2);
            
            Console.WriteLine("Enter file name:");
            string fileName = Console.ReadLine();
            
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not exists. Creating new file...");
                File.Create(fileName);
            }
            else
            {
                magazine1.Load(fileName);
            }
            
            Console.WriteLine("-------------------------------");
            Console.WriteLine(magazine1);

            magazine1.AddFromConsole();
            magazine1.Save(fileName);
            
            Console.WriteLine("-------------------------------");
            Console.WriteLine(magazine1);

            Magazine.Load(fileName, magazine1);
            magazine1.AddFromConsole();
            Magazine.Save(fileName, magazine1);

            Console.WriteLine("-------------------------------");
            Console.WriteLine(magazine1);
        }
    }
}