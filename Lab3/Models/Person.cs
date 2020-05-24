using System;

namespace Lab3
{
    internal class Person
    {
        private string _personName;
        private string _personLastName;
        private DateTime _personBirthday;

        public string PersonName
        {
            get { return _personName; }
            set { _personName = value; }
        }

        public string PersonLastName
        {
            get { return _personLastName; }
            set { _personLastName = value; }
        }

        public DateTime PersonBirthday
        {
            get { return _personBirthday; }
            set { _personBirthday = value; }
        }
        
        public int PersonBirthdayYear
        {
            get { return _personBirthday.Year; }
            set { _personBirthday = new DateTime(value, _personBirthday.Month, _personBirthday.Day); }
        }
        
        public Person():this("default Name", "default Last Name", new DateTime())
        {
        }

        public Person(string personName, string personLastName, DateTime personBirthday)
        {
            _personName = personName;
            _personLastName = personLastName;
            _personBirthday = personBirthday;
        }

        public override string ToString()
        {
            return string.Format("  PersonName: {0},\n   PersonLastName: {1},\n   PersonBirthday: {2}", _personName, _personLastName, _personBirthday.ToShortDateString());
        }

        public string ToShortString()
        {
            return string.Format("PersonName: {0}, PersonLastName: {1}", _personName, _personLastName);
        }      
                
        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }

        protected bool Equals(Person other)
        {
            return string.Equals(_personName, other._personName) && string.Equals(_personLastName, other._personLastName) && _personBirthday.Equals(other._personBirthday);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Person) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_personName != null ? _personName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_personLastName != null ? _personLastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _personBirthday.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Person left, Person right)
        {
            return ReferenceEquals(left, right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !ReferenceEquals(left, right);
        }
    }
}