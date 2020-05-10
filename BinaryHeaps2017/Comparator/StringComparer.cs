using BinaryHeaps2017.Comparator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017.Comparator
{
    class StringToCountComparer : IComparer<StringToCount>
    {
        public int Compare(StringToCount x, StringToCount y)
        {
            if (x.count > y.count)
                return 1;
            else if (x.count < y.count)
                return -1;
            else
            {
                return y.str.CompareTo(x.str);
            }
        }
    }
}
