namespace Lab4
{
    internal class Article : IRateAndCopy
    {
        public Person PersonInformation { get; set; }
        public string ArticleName { get; set; }
        public double ArticleRage { get; set; }

        public double Raiting { get; private set; }
        
        public Article():this(new Person(), "New Article", 0)
        {
        }

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
                
        public virtual object DeepCopy()
        {
            return MemberwiseClone();
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

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (PersonInformation != null ? PersonInformation.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ArticleName != null ? ArticleName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ArticleRage.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Article left, Article right)
        {
            return ReferenceEquals(left, right);
        }

        public static bool operator !=(Article left, Article right)
        {
            return !ReferenceEquals(left, right);
        }
    }
}