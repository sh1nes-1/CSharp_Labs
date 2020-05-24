using System;
using System.Collections.Generic;

namespace Lab3
{
    internal class Edition : IRateAndCopy, IComparable, IComparer<Edition>
    {
        public string EditionName { get; set; }
        public DateTime EditionDate { get; set; }
        private int _editionCirculation;
        public int EditionCirculation
        {
            get { return _editionCirculation; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("EditionCirculation must be more then 0");
                }

                _editionCirculation = value;
            }
        }
        
        public double Raiting { get; private set; }

        public Edition() : this("Edition Ksenya", DateTime.Today, 1){}
        
        public Edition(string editionName, DateTime editionDate, int editionCirculation)
        {
            EditionName = editionName;
            EditionDate = editionDate;
            EditionCirculation = editionCirculation;
        }
        
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
        
            Edition otherEdition = obj as Edition;
            if (otherEdition != null) 
                return String.Compare(EditionName, otherEdition.EditionName, StringComparison.Ordinal);
            throw new ArgumentException("Object is not a Edition");
        }

        public int Compare(Edition x, Edition y)
        {
            if (x.EditionDate.CompareTo(y.EditionDate) != 0)
            {
                return x.EditionDate.CompareTo(y.EditionDate);
            }

            return 0;
        }

        public override string ToString()
        {
            return string.Format("EditionName: {0}, EditionDate: {1}, EditionCirculation: {2}", EditionName, EditionDate.ToShortDateString(), EditionCirculation);
        }
                
        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }

        protected bool Equals(Edition other)
        {
            return string.Equals(EditionName, other.EditionName) && EditionDate.Equals(other.EditionDate) && EditionCirculation == other.EditionCirculation;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Edition) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (EditionName != null ? EditionName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ EditionDate.GetHashCode();
                hashCode = (hashCode * 397) ^ EditionCirculation;
                return hashCode;
            }
        }
       
        public static bool operator ==(Edition left, Edition right)
        {
            return ReferenceEquals(left, right);
        }

        public static bool operator !=(Edition left, Edition right)
        {
            return !ReferenceEquals(left, right);
        }
    }
}