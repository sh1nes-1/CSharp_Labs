using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Lab1
{
    class Program
    {
        static void PrintOneDimensionTime(int nRows, int nCols)
        {
            Article[] oneDimensionArray = new Article[nRows * nCols];
            for (int i = 0; i < oneDimensionArray.Length; i++)
                oneDimensionArray[i] = new Article();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //int timeOneDimensionBefore = Environment.TickCount;

            double oneDimensionSum = 0;
            int oneDimensionLength = nRows * nCols;
            for (int i = 0; i < oneDimensionLength; i++)
                oneDimensionSum += oneDimensionArray[i].Rating;
            oneDimensionSum /= oneDimensionLength;
            sw.Stop();
            //int timeOneDimensionAfter = Environment.TickCount;

            Console.WriteLine($"Time of one dimension array: {sw.ElapsedMilliseconds}");
            oneDimensionArray = null;
        }

        static void PrintTwoDimensionTime(int nRows, int nCols)
        {
            Article[,] twoDimensionArray = new Article[nRows, nCols];
            for (int i = 0; i < nRows; i++)
                for (int j = 0; j < nCols; j++)
                    twoDimensionArray[i, j] = new Article();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //int timeTwoDimensionBefore = Environment.TickCount;

            double twoDimensionSum = 0;
            for (int i = 0; i < nRows; i++)
                for (int j = 0; j < nCols; j++)
                    twoDimensionSum += twoDimensionArray[i, j].Rating;
            twoDimensionSum /= nRows * nCols;

            sw.Stop();
            //int timeTwoDimensionAfter = Environment.TickCount;

            Console.WriteLine($"Time of two dimension array: {sw.ElapsedMilliseconds}");
            twoDimensionArray = null;
        }

        static void PrintTeethArrayTime(int nRows, int nCols)
        {
            List<int> rowsElementsCounts = new List<int>();
            int freeElementsCount = nRows * nCols;
            while (freeElementsCount > 0)
            {
                Console.Write($"Enter count of elements in row {rowsElementsCounts.Count} (remains {freeElementsCount}): ");
                string rawCount = Console.ReadLine();
                if (int.TryParse(rawCount, out int count) && count <= freeElementsCount && count > 0)
                {
                    rowsElementsCounts.Add(count);
                    freeElementsCount -= count;
                }
            }

            Article[][] teethArray = new Article[rowsElementsCounts.Count][];
            for (int i = 0; i < rowsElementsCounts.Count; i++)
            {
                teethArray[i] = new Article[rowsElementsCounts[i]];
                for (int j = 0; j < rowsElementsCounts[i]; j++)
                    teethArray[i][j] = new Article();
            }
            
            Stopwatch sw = new Stopwatch();
            sw.Start();

            double teethSum = 0;
            for (int i = 0; i < teethArray.Length; i++)
                for (int j = 0; j < teethArray[i].Length; j++)
                    teethSum += teethArray[i][j].Rating;
            teethSum /= nRows * nCols;

            //int timeTeethAfter = Environment.TickCount;
            sw.Stop();

            Console.WriteLine($"Time of teeth dimension array: {sw.ElapsedMilliseconds}");
            teethArray = null;
        }

        static void Main(string[] args)
        {
            Person person = new Person("AuthorFirstName", "AuthorLastName", new DateTime(1849, 9, 13));
            Console.WriteLine(person);
            Article myArticle = new Article(person, "My Article", 5);

            Magazine magazine = new Magazine("Weekly magazine", Frequency.WEEKLY, new DateTime(2020, 2, 10), 50);
            magazine.AddArticles(new Article());
            Console.WriteLine(magazine.ToShortString());
  
            Console.WriteLine("Is magazine weekly: " + magazine[Frequency.WEEKLY]);
            Console.WriteLine("Is magazine montly: " + magazine[Frequency.MONTLY]);
            Console.WriteLine("Is magazine yearly: " + magazine[Frequency.YEARLY]);

            magazine.Name = "Montly magazine";
            magazine.Articles = new Article[] { myArticle };
            magazine.Frequency = Frequency.MONTLY;
            magazine.Quantity = 22;
            magazine.ReleaseDate = new DateTime(2020, 3, 10);
            Console.WriteLine(magazine.ToString());

            magazine.AddArticles(new Article(person, "Some new article", 7));
            Console.WriteLine(magazine.ToString());

            Console.WriteLine("\n");
            Console.WriteLine("Enter nRows {divider} nCols");
            Console.WriteLine("Allowed dividers: '*', 'x', ',', ' '");
            string rawInput = Console.ReadLine();

            string[] nSize = rawInput.Split('*', 'x', ',', ' ');
            int nRows = int.Parse(nSize[0].Trim());
            int nCols = int.Parse(nSize[1].Trim());

            PrintOneDimensionTime(nRows, nCols);
            GC.Collect();

            PrintTwoDimensionTime(nRows, nCols);
            GC.Collect();

            PrintTeethArrayTime(nRows, nCols);
            GC.Collect();

            Console.ReadLine();
        }
    }
}
