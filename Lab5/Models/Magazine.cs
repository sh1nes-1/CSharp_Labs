using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Lab5
{
    [Serializable]
    internal class Magazine : Edition
    {
        private string _magazineName;
        private Frequency _timing;
        private DateTime _magazineDate;
        private int _magazineCirculation;
        private List<Person> _personsList;
        private List<Article> _articleList;

        public double MiddleRate
        {
            get
            {
                double allRanges = 0;
                foreach (Article article in ArticleList)
                {
                    allRanges += article.ArticleRage;
                }
                return allRanges / ArticleList.Count ;
            }
        }
        
        public Edition EditionBase
        {
            get { return new Edition(EditionName, EditionDate, EditionCirculation);}
            set
            {
                EditionName = value.EditionName;
                EditionDate = value.EditionDate;
                EditionCirculation = value.EditionCirculation;
            }
        }
        
        public string MagazineName
        {
            get { return _magazineName; }
            set { _magazineName = value; }
        }

        public Frequency Timing
        {
            get { return _timing; }
            set { _timing = value; }
        }

        public DateTime MagazineDate
        {
            get { return _magazineDate; }
            set { _magazineDate = value; }
        }
        
        public int MagazineCirculation
        {
            get { return _magazineCirculation; }
            set { _magazineCirculation = value; }
        }

        public List<Person> PersonsList
        {
            get { return _personsList; }
            set { _personsList = value; }
        }

        public List<Article> ArticleList
        {
            get { return _articleList; }
            set { _articleList = value; }
        }
        
        public bool this[Frequency frequency]
        {
            get { return _timing == frequency; }
        }
        
        public Magazine() : this(new Edition(), "default name", Frequency.Weekly, new DateTime(), 0,
            new List<Person> {new Person()}, new List<Article> {new Article()})
        {    
        }

        public Magazine(Edition edition, string magazineName, Frequency timing, DateTime magazineDate,
            int magazineCirculation, List<Person> personsList, List<Article> articleList) 
            : base(edition.EditionName, edition.EditionDate, edition.EditionCirculation)
        {
            _magazineName = magazineName;
            _timing = timing;
            _magazineDate = magazineDate;
            _magazineCirculation = magazineCirculation;
            _personsList = personsList;
            _articleList = articleList;
        }        
  
        public void AddArticles(params Article[] article)
        {
            if (article != null)
            {
                ArticleList.AddRange(article);
            }            
        }

        public void AddEditors(params Person[] person)
        {
            if (person != null)
            {
                PersonsList.AddRange(person);
            }
        }
        
        public IEnumerable GetArticlesMoreThan(double lowValue)
        {
            foreach (Article article in ArticleList)
            {
                if (article.ArticleRage > lowValue)
                {
                    yield return article;
                }
            }
        }
        
        public IEnumerable GetArticlesWithText(string text)
        {
            foreach (Article article in ArticleList)
            {
                if (article.ArticleName.Contains(text))
                {
                    yield return article;
                }
            }
        }

        public bool AddFromConsole()
        {
            try
            {
                Console.WriteLine("Hello, you can enter here Article in format:\n" +
                                  "PersonName PersonLastName PersonBirth(dd.mm.yyyy) ArticleName ArticleRage,   " +
                                  "use space as text split");
                string[] input = Console.ReadLine().Split(' ');
             /*   if (input.Length % 5 != 0)
                {
                    throw new Exception("Input Error");
                }*/

                int i = 0;
                while (i < input.Length)
                {
                    string personName = input[i++];
                    string personLastName = input[i++];
                    DateTime personBirth = DateTime.ParseExact(input[i++], "dd.MM.yyyy", null);
                    string articleName = input[i++];
                    int articleRage = Int32.Parse(input[i++]);
                    
                    AddArticles(new Article(new Person(personName, personLastName, personBirth), articleName, articleRage));
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Save(string filename)
        {
            try
            {
                using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);                 
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }                       
        }

        public bool Load(string filename)
        {

            using (FileStream stream = new FileStream(filename, FileMode.Open))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Magazine magazine = (Magazine)formatter.Deserialize(stream);
                    
                    this.MagazineName = magazine.MagazineName;
                    this.Timing = magazine.Timing;
                    this.MagazineDate = magazine.MagazineDate;
                    this.MagazineCirculation = magazine.MagazineCirculation;
                    this.ArticleList = magazine.ArticleList;
                    this.PersonsList = magazine.PersonsList;
                    this.EditionBase = magazine.EditionBase;
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
                            
            }
        }
        
        public static bool Save(string filename, Magazine obj)
        {
            return obj.Save(filename);
        }

        public static bool Load(string filename, Magazine obj)
        {
            return obj.Load(filename);
        }
        
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            foreach (var article in ArticleList)
            {
                stringBuilder.AppendLine(article.ToString());
            }
            stringBuilder.AppendLine("Persons:");
            foreach (var person in PersonsList)
            {
                stringBuilder.AppendLine(person.ToString());
            }
            return string.Format(
                " MagazineName: {0},\n Timing: {1},\n MagazineDate: {2},\n Article: {3},\n MiddleRate: {4}\n",
                MagazineName, Timing, MagazineDate.ToShortDateString(), stringBuilder, MiddleRate);
        }

        public virtual string ToShortString()
        {
            return string.Format(" MagazineName: {0},\n Timing: {1},\n MagazineDate: {2},\n MiddleRate: {3}\n",
                MagazineName, Timing, MagazineDate.ToShortDateString(), MiddleRate);
        }

        public override object DeepCopy()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }

                return null;
            }
        }

        protected bool Equals(Magazine other)
        {
            return string.Equals(_magazineName, other._magazineName) && _timing == other._timing &&
                   _magazineDate.Equals(other._magazineDate) && _magazineCirculation == other._magazineCirculation &&
                   _articleList.SequenceEqual(other._articleList) && _personsList.SequenceEqual(other._personsList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Magazine) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_magazineName != null ? _magazineName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) _timing;
                hashCode = (hashCode * 397) ^ _magazineDate.GetHashCode();
                hashCode = (hashCode * 397) ^ _magazineCirculation;
                hashCode = (hashCode * 397) ^ (_articleList != null ? _articleList.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Magazine left, Magazine right)
        {
            return ReferenceEquals(left, right);
        }

        public static bool operator !=(Magazine left, Magazine right)
        {
            return !ReferenceEquals(left, right);
        }
    }
}