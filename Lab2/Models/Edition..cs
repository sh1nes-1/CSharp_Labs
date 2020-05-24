using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Edition : IRateAndCopy
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

        public Edition() : this("Edition", DateTime.Today, 1){}
        
        public Edition(string editionName, DateTime editionDate, int editionCirculation)
        {
            EditionName = editionName;
            EditionDate = editionDate;
            EditionCirculation = editionCirculation;
        }

        public double Rating { get; private set; }

        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return string.Format("EditionName: {0}, EditionDate: {1}, EditionCirculation: {2}", EditionName, EditionDate, EditionCirculation);
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
            int hashCode = 1328352786;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EditionName);
            hashCode = hashCode * -1521134295 + EditionDate.GetHashCode();
            hashCode = hashCode * -1521134295 + _editionCirculation.GetHashCode();
            return hashCode;
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