using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Person
    {
        private string _personName;
        private string _personLastName;
        private DateTime _personBirthday;

        public Person() : this("default Name", "default Last Name", new DateTime())
        {

        }

        public Person(string personName, string personLastName, DateTime personBirthday)
        {
            _personName = personName;
            _personLastName = personLastName;
            _personBirthday = personBirthday;
        }

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

        public override string ToString()
        {
            return string.Format("  PersonName: {0},\n   PersonLastName: {1},\n   PersonBirthday: {2}", _personName, _personLastName, _personBirthday);
        }

        public string ToShortString()
        {
            return string.Format("PersonName: {0}, PersonLastName: {1}", _personName, _personLastName);
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
            int hashCode = 1547291586;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_personName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_personLastName);
            hashCode = hashCode * -1521134295 + _personBirthday.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Person left, Person right)
        {
            return ReferenceEquals(left, right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }
        
        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }
    }
}