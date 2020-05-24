using System;
using System.Linq;

namespace Lab4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MagazineCollection magazine1 = new MagazineCollection();
            MagazineCollection magazine2 = new MagazineCollection();
            magazine1.CollectionName = "Magazine1";
            magazine2.CollectionName = "Magazine2";
            
            Listener listener1 = new Listener();
            magazine1.MagazineAdded += listener1.AddEvent;
            magazine1.MagazineReplaced += listener1.AddEvent;
            
            Listener listener2 = new Listener();
            magazine1.MagazineAdded += listener2.AddEvent;
            magazine2.MagazineAdded += listener2.AddEvent;
            magazine1.MagazineReplaced += listener2.AddEvent;
            magazine2.MagazineReplaced += listener2.AddEvent;

            magazine1.AddMagazines(new Magazine());
            magazine2.AddMagazines(new Magazine());
            magazine1.AddDefaults();
            magazine2.AddDefaults();

            Console.WriteLine("<<<<<<<<<<<< LISTENER 1 >>>>>>>>>>>>");
            Console.WriteLine(listener1);

            Console.WriteLine();

            Console.WriteLine("<<<<<<<<<<<< LISTENER 2 >>>>>>>>>>>>");
            Console.WriteLine(listener2);

            Console.ReadKey();

        }
    }
}