using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    class Article
    {
        private Person _author;
        private string _name;
        private double _rating;

        public Person Author { get => _author; set => _author = value; }
        public string Name { get => _name; set => _name = value; }
        public double Rating { get => _rating; set => _rating = value; }
        
        public Article()
        {
            Author = new Person();
            Name = "Empty Article";
            Rating = 10;
        }

        public Article(Person author, string name, double rating)
        {
            Author = author;
            Name = name;
            Rating = rating;
        }

        public override string ToString()
        {
            return Author + " " + Name + " " + Rating;
        }
    }
}
