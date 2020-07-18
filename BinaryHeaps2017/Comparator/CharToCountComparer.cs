using BinaryHeaps2017.Comparator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017.Comparator
{
    class CharToCountComparer : IComparer<CharToCount>
    {
        public int Compare(CharToCount x, CharToCount y)
        {
            if (x.count > y.count)
                return 1;
            else if (x.count < y.count)
                return -1;

            return 0;
        }
    }
}
