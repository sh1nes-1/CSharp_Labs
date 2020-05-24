using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    internal class TestCollections
    {
        public List<Edition> Editions { get; set; } 
        public List<string> Text { get; set; }
        public Dictionary<Edition, Magazine> EdMagDictionary { get; set; }
        public Dictionary<string, Magazine> StMagDictionary { get; set; }

        public static Magazine GetMegazine(int index)
        {
            Magazine magazine = new Magazine(
                new Edition(
                    "editionName " + index, 
                    DateTime.Today.AddDays(index), 
                    index),
                "magazineName " + index,
                Frequency.Montly, 
                DateTime.Today.AddDays(index + 1),
                index,
                new List<Person>
                {
                    new Person("personName " + index + 1,
                        "personLast " + index + 1,
                        DateTime.Today.AddDays(index + 2)),
                    new Person("personName " + index + 2,
                        "personLast " + index + 2,
                        DateTime.Today.AddDays(index + 3)),
                    new Person("personName " + index + 3,
                        "personLast " + index + 3,
                        DateTime.Today.AddDays(index + 4))
                },
                new List<Article>
                {
                    new Article(new Person("personName " + index + 1 ,
                        "personLast " + index + 1,
                        DateTime.Today.AddDays(index + 5)),
                        "articleName " + index,
                        index), 
                    new Article(new Person("personName " + index + 2 ,
                        "personLast " + index + 2,
                        DateTime.Today.AddDays(index + 6)),
                        "articleName " + index + 2,
                        index), 
                    new Article(new Person("personName " + index + 3 ,
                        "personLast " + index + 3,
                        DateTime.Today.AddDays(index + 7)),
                        "articleName " + index + 3,
                        index) 
                });
            return magazine;
        }

        public TestCollections(int count)
        {
            Editions = new List<Edition>();
            Text = new List<string>();
            EdMagDictionary = new Dictionary<Edition, Magazine>();
            StMagDictionary = new Dictionary<string, Magazine>();
            
            for (int i = 0; i < count; i++)
            {
                Magazine magazine = GetMegazine(i);
                Edition edition = magazine.EditionBase;

                Editions.Add(edition);
                Text.Add(edition.ToString());
                EdMagDictionary.Add(edition, magazine);
                StMagDictionary.Add(edition.ToString(), magazine);  
            }           
        }

        public void MeasureTime()
        {
            int length = Editions.Count - 1;
            int[] indexes = {0, length, length / 2, length + 1};
            foreach (var index in indexes)
            {
                var searcherMagazine = GetMegazine(index);
                var searcherEdition = searcherMagazine.EditionBase;
                
                Console.WriteLine("----------------------------");
                
                var start = Environment.TickCount;
                var answer = Editions.Contains(searcherEdition);
                var end = Environment.TickCount;
                Console.WriteLine("List edition at index {0}: " + (end - start) + " {1}", index, answer); 
                
                start = Environment.TickCount;
                answer = Text.Contains(searcherEdition.ToString());
                end = Environment.TickCount;
                Console.WriteLine("List edition toString at index {0}: " + (end - start) + " {1}", index, answer);
                
                start = Environment.TickCount;
                answer = EdMagDictionary.ContainsKey(searcherEdition);
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<Edition, Magazine> key at index {0}: " + (end - start) + " {1}", index, answer);
                
                start = Environment.TickCount;
                answer = EdMagDictionary.ContainsValue(searcherMagazine);
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<Edition, Magazine> value at index {0}: " + (end - start) + " {1}", index, answer);
                
                start = Environment.TickCount;
                answer = StMagDictionary.ContainsKey(searcherEdition.ToString());
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<string, Magazine> key at index {0}: " + (end - start) + " {1}", index, answer);
                
                start = Environment.TickCount;
                answer = StMagDictionary.ContainsValue(searcherMagazine);
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<string, Magazine> value at index {0}: " + (end - start) + " {1}", index, answer);
            }
            
        }
    }
}