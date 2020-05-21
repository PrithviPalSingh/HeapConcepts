using BinaryHeaps2017.Comparator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017.Comparator
{
    class NumToListComparer : IComparer<NumToList>
    {
        public int Compare(NumToList x, NumToList y)
        {
            if (x.number > y.number)
                return 1;
            else if (x.number < y.number)
                return -1;
            else
                return 0;
        }
    }
}
