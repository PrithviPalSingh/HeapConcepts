using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017.Comparator.Entities
{
    class NumToList
    {
        public int number;
        public List<int> list;

        public NumToList(int num, List<int> list)
        {
            this.number = num;
            this.list = list;
        }
    }
}
