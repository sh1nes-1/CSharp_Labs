using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    class Person
    {
        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }
        public int Year 
        { 
            get => BirthDate.Year;
            set => BirthDate = new DateTime(value, BirthDate.Month, BirthDate.Day); 
        }

        public Person()
        {
            FirstName = "Serhiy";
            LastName = "Kosovchych";
            BirthDate = new DateTime(2000, 1, 7);
        }

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return LastName + " " + FirstName + " " + BirthDate.ToLongDateString();
        }

        public virtual string ToShortString()
        {
            return LastName + " " + FirstName;
        }
    }
}
