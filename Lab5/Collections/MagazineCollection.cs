using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    internal class MagazineCollection
    {
        public delegate void MagazineListHandler(object source, MagazineListHandlerEventArgs args);

        public event MagazineListHandler MagazineAdded;
        public event MagazineListHandler MagazineReplaced;
        
        public List<Magazine> Magazines { get; set; }
        public string CollectionName { get; set; }

        public MagazineCollection()
        {
            Magazines = new List<Magazine>();
            CollectionName = "NoName";
        }
        
        public bool Replace(int j, Magazine magazine)
        {
            if (Magazines.Count > j)
            {
                Magazines[j] = magazine;
                if (MagazineReplaced != null)
                    MagazineReplaced(this, new MagazineListHandlerEventArgs(CollectionName, "Element was replaced by Replace", j));
                return true;
            }
            return false;
        }
        
        public void AddDefaults()
        {
            Magazine fullMagazine = new Magazine(new Edition("name33", DateTime.Now, 123), "name1", Frequency.Montly, DateTime.Now, 10, 
                new List<Person>
                {
                    new Person(), new Person()
                }, 
                new List<Article>
                {
                    new Article(new Person(), "1", 50 ), new Article(new Person(), "2", 80 )
                });
            Magazines.Add(fullMagazine);
            if (MagazineAdded != null)
                MagazineAdded(this, new MagazineListHandlerEventArgs(CollectionName,"Element was added by AddDEfaults",Magazines.Count - 1));
            Magazines.Add(new Magazine());
            if (MagazineAdded != null)
                MagazineAdded(this, new MagazineListHandlerEventArgs(CollectionName,"Element was added by AddDEfaults",Magazines.Count - 1));
            Magazines.Add(fullMagazine);
            if (MagazineAdded != null)
                MagazineAdded(this, new MagazineListHandlerEventArgs(CollectionName,"Element was added by AddDEfaults",Magazines.Count - 1));
        }

        public void AddMagazines(params Magazine[] magazines)
        {
            foreach (var magazine in magazines)
            {
                Magazines.Add(magazine);
                if (MagazineAdded != null)
                    MagazineAdded(this, new MagazineListHandlerEventArgs(
                        CollectionName,
                        "Element was added by AddMagazines",
                        Magazines.Count - 1));
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

        public Magazine this[int index]
        {
            get { return Magazines[index]; }
            set
            {
                Magazines[index] = value;
                if (MagazineReplaced != null)
                    MagazineReplaced(this,
                        new MagazineListHandlerEventArgs(CollectionName, "Element was replaced by indexator", index));
            }
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