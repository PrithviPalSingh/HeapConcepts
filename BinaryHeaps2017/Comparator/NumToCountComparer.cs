using BinaryHeaps2017.Comparator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017.Comparator
{
    class NumToCountComparer : IComparer<NumToCount>
    {
        public int Compare(NumToCount x, NumToCount y)
        {
            if (x.count > y.count)
                return 1;
            else if (x.count < y.count)
                return -1;
            else
                return 0;
        }
    }
}
