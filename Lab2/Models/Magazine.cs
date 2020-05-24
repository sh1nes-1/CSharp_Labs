using System;
using System.Collections;
using System.Text;

namespace Lab2
{
    public class Magazine : Edition
    {
        private string _magazineName;
        private Frequency _timing;
        private DateTime _magazineDate;
        private int _magazineCirculation;
        private ArrayList _personsList;
        private ArrayList _articleList;

        public bool this[Frequency frequency]
        {
            get { return _timing == frequency; }
        }
        
        public Magazine() : this("Magazine", Frequency.Weekly, new DateTime(), 0, new ArrayList(), new ArrayList())
        {
    
        }

        public Magazine(string magazineName, Frequency timing, DateTime magazineDate, int magazineCirculation, ArrayList personsList, ArrayList articleList)
        {
            _magazineName = magazineName;
            _timing = timing;
            _magazineDate = magazineDate;
            _magazineCirculation = magazineCirculation;
            _personsList = personsList;
            _articleList = articleList;
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

        public ArrayList PersonsList
        {
            get { return _personsList; }
            set { _personsList = value; }
        }

        public ArrayList ArticleList
        {
            get { return _articleList; }
            set { _articleList = value; }
        }

       public double MiddleRate
        {
            get
            {
                double allRanges = 0;
                foreach (Article article in ArticleList)
                {                    allRanges += article.ArticleRage;
                }
                return allRanges / ArticleList.Count ;
            }
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
            return string.Format(" MagazineName: {0},\n Timing: {1},\n MagazineDate: {2},\n Article: {3},\n MiddleRate: {4}\n", MagazineName, Timing, MagazineDate, stringBuilder, MiddleRate);
        }

        public virtual string ToShortString()
        {
            return string.Format(" MagazineName: {0},\n Timing: {1},\n MagazineDate: {2},\n MiddleRate: {3}\n", MagazineName, Timing, MagazineDate, MiddleRate);
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

        protected bool Equals(Magazine other)
        {
            return string.Equals(_magazineName, other._magazineName) && _timing == other._timing && _magazineDate.Equals(other._magazineDate) && _magazineCirculation == other._magazineCirculation && Equals(_articleList, other._articleList);
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
        
        public override object DeepCopy()
        {
            Magazine other = (Magazine) MemberwiseClone();
            other.PersonsList = new ArrayList();
            other.ArticleList = new ArrayList();
            foreach (Person person in PersonsList)
                other.PersonsList.Add(person.DeepCopy());
            foreach (Article article in ArticleList)
                other.ArticleList.Add(article.DeepCopy());
            return other;
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
    }
}