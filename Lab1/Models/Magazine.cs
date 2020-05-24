using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    class Magazine
    {
        private string _name;
        private Frequency _frequency;
        private DateTime _releaseDate;
        private int _quantity; // тираж
        private Article[] _articles;

        public string Name { get => _name; set => _name = value; }
        public Frequency Frequency { get => _frequency; set => _frequency = value; }
        public DateTime ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public Article[] Articles { get => _articles; set => _articles = value; }

        public double AvgRating { get => Articles.Average(a => a.Rating); }
        public bool this[Frequency index] { get => Frequency.Equals(index); }

        public Magazine()
        {
            Name = "Some magazine";
            Frequency = Frequency.MONTLY;
            Quantity = 5;
            ReleaseDate = new DateTime(2020, 2, 12);
            Articles = new Article[] { new Article() };
        }

        public Magazine(string name, Frequency frequency, DateTime releaseDate, int quantity)
        {
            Name = name;
            Frequency = frequency;
            ReleaseDate = releaseDate;
            Quantity = quantity;
            Articles = new Article[] { };
        }

        public void AddArticles(params Article[] articles)
        {
            Articles = Articles.Concat(articles).ToArray();
        }

        public override string ToString()
        {
            return Name + " " + Frequency + " " + ReleaseDate.ToShortDateString() + " " + Quantity + " " + string.Join(" ", Articles.Select(a => a.Name));
        }

        public virtual string ToShortString()
        {
            return Name + " " + Frequency + " " + ReleaseDate.ToShortDateString() + " " + Quantity + " " + AvgRating;
        }
    }
}
