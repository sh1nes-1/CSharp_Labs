using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    internal class MagazineCollection
    {
        public List<Magazine> Magazines { get; set; }

        public void AddDefaults()
        {
            Magazines = new List<Magazine>();
            Magazine fullMagazine = new Magazine(new Edition("Edition 1", DateTime.Now, 100), "Magazine 1", Frequency.Montly, DateTime.Now, 5, 
                new List<Person>
                {
                    new Person(), new Person()
                }, 
                new List<Article>
                {
                    new Article(new Person(), "1", 10 ), new Article(new Person(), "2", 50 )
                });
            Magazines.Add(fullMagazine);
            Magazines.Add(new Magazine());            
            Magazines.Add(fullMagazine);
        }

        public void AddMagazines(params Magazine[] magazines)
        {
            Magazines = new List<Magazine>();
            foreach (var magazine in magazines)
            {
                Magazines.Add(magazine);
            }
        }

        public double GetMaxMiddleRate()
        {           
            return Magazines.Count != 0 ? Magazines.Select(x => x.MiddleRate).Max() : 0;
        }

        public IEnumerable<Magazine> GetMontlyMagazines()
        {
            return Magazines.Where(x => x.Timing == Frequency.Montly);
        }

        public List<Magazine> GetRatingGroup(double value)
        {
            return Magazines.Where(x => x.MiddleRate >= value).ToList();
        }

        public void SortByName()
        {
            Magazines.Sort();
        }

        public void SortByDate()
        {
           Magazines.Sort(new Edition().Compare);
        }

        public void SortByCirculation()
        {
            Magazines.Sort(new EditionCirculationCompare().Compare);  
        }
        
        public override string ToString()
        {
            return string.Format("Magazines:\n{0}", string.Join("\n", Magazines.Select(x => x.ToString()).ToArray()));
        }
        
        public virtual string ToShortString()
        {
            return string.Format("Magazines:\n{0}", string.Join("\n", Magazines.Select(x => x.ToShortString()).ToArray()));
        }
    }
}