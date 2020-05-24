  using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MagazineCollection magazineCollection = new MagazineCollection();
            magazineCollection.AddMagazines(
                    TestCollections.GetMegazine(4),
                    TestCollections.GetMegazine(3),
                    TestCollections.GetMegazine(5),
                    TestCollections.GetMegazine(1),
                    TestCollections.GetMegazine(2)
                );
            
            Console.WriteLine("MagazineCollection default: \n {0}\n", string.Join(" ; ", magazineCollection.Magazines.Select(x => x.EditionName).ToArray()) );
           
            magazineCollection.SortByName();
            Console.WriteLine("Sorted by Name: \n {0}\n", string.Join(" ; ", magazineCollection.Magazines.Select(x => x.EditionName).ToArray()) );
            
            magazineCollection.SortByDate();
            Console.WriteLine("Sorted by Date: \n {0}\n", string.Join(" ; ", magazineCollection.Magazines.Select(x => x.EditionName).ToArray()) );
            
            magazineCollection.SortByCirculation();
            
            Console.WriteLine("Sorted by Circulation: \n {0}\n", string.Join(" ; ", magazineCollection.Magazines.Select(x => x.EditionName).ToArray()) );
            
            Console.WriteLine("Maximum middle rate: {0}\n", magazineCollection.GetMaxMiddleRate());
            
            Console.WriteLine("Magazines with Frequency = Monthly:\n {0}\n",
                string.Join(" ; ", magazineCollection.GetMontlyMagazines().Select(x => x.MagazineName).ToArray()));

                double value = 4         ;
            Console.WriteLine("Student with middle score more than {0}:\n {1}\n", value,
                string.Join(" ; ", magazineCollection.GetRatingGroup(value).Select(x => x.MagazineName).ToArray()));
            
            TestCollections test = new TestCollections(10);
            Console.WriteLine("Searching time:");
            test.MeasureTime();
            Console.ReadKey();
        }
    }
}