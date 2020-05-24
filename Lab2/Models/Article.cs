using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Lab2
{
    public class Article : IRateAndCopy
    {
        public Person PersonInformation { get; set; }
        public string ArticleName { get; set; }
        public double ArticleRage { get; set; }

        public Article() : this(new Person(), "Article", 0) {}

        public Article(Person personInformation, string articleName, double articleRage)
        {
            PersonInformation = personInformation;
            ArticleName = articleName;
            ArticleRage = articleRage;
        }
        
        public override string ToString()
        {
            return string.Format("PersonInformation: \n {0},\n  ArticleName: {1},\n  ArticleRage: {2}", PersonInformation, ArticleName, ArticleRage);
        }

        protected bool Equals(Article other)
        {
            return Equals(PersonInformation, other.PersonInformation) && string.Equals(ArticleName, other.ArticleName) && ArticleRage.Equals(other.ArticleRage);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Article) obj);
        }

        public static bool operator ==(Article left, Article right)
        {
            return ReferenceEquals(left, right);
        }

        public static bool operator !=(Article left, Article right)
        {
            return !ReferenceEquals(left, right);
        }

        public double Rating { get; private set; }
        
        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }

        public override int GetHashCode()
        {
            int hashCode = 621761120;
            hashCode = hashCode * -1521134295 + EqualityComparer<Person>.Default.GetHashCode(PersonInformation);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ArticleName);
            hashCode = hashCode * -1521134295 + ArticleRage.GetHashCode();
            return hashCode;
        }
    }
}