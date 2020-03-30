using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017
{
    class MaxBinaryHeap<T> where T: IComparable<T>
    {
        int size;
        int N;
        T[] items;

        public MaxBinaryHeap(int s)
        {
            this.size = s;
            this.N = 0;
            items = new T[s];
        }

        public void Insert(T a)
        {
            items[N] = a;
            swim(N);
            N++;
        }

        public T DeleteMax()
        {
            var a = items[0];
            swap(0, --N);
            sink(0);
            return a;
        }

        public T Peek()
        {
            return items[0];
        }

        private void swim(int index)
        {
            var j = (index - 1) / 2;

            while (index > 0 && items[index].CompareTo(items[j]) > 0)
            {
                swap(index, j);
                index = j;
                j= (index - 1) / 2;
            }
        }

        private void sink(int index)
        {
            while (index >=0 && index < N)
            {
                var i = (2 * index) + 1;
                var j = (2 * index) + 2;

                var swapindex = -1;
                if (i < N)
                {
                    swapindex = items[i].CompareTo(items[j]) > 0 ? i : j;
                    swap(index, swapindex);
                }

                index = swapindex;
            }
        }

        private void swap(int i, int j)
        {
            var temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
