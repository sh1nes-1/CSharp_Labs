using System.Collections.Generic;

namespace Lab4
{
    internal class EditionCirculationCompare:IComparer<Edition>
    {
        public int Compare(Edition x, Edition y)
        {
            if (x.EditionCirculation.CompareTo(y.EditionCirculation) != 0)
            {
                return x.EditionCirculation.CompareTo(y.EditionCirculation);
            }

            return 0;
        }
    }
}