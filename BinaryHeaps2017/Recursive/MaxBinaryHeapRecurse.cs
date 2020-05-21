using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017
{
    class MaxBinaryHeapRecurse<T>
    {
        T[] items;
        int capacity;
        int size;
        IComparer<T> comparer;

        public MaxBinaryHeapRecurse(int cap, IComparer<T> comp)
        {
            this.items = new T[cap];
            this.capacity = cap;
            this.size = 0;
            this.comparer = comp;
        }

        public void Insert(T val)
        {
            if (capacity == size)
            {
                //Console.WriteLine("Cannot insert");
                return;
            }

            size++;
            int i = size - 1;
            items[i] = val;

            while (i != 0 && lesser(parent(i), i))
            {
                swap(i, parent(i));
                i = parent(i);
            }
        }

        void deleteKey(int i)
        {
            if (size <= 0 || i > size - 1)
                return;

            DecreaseKey(i, default(T));
            DeleteMax();
        }

        public void DecreaseKey(int i, T new_val)
        {
            items[i] = new_val;
            while (i != 0 && lesser(parent(i), i))
            {
                swap(i, parent(i));
                i = parent(i);
            }
        }

        public T Peek()
        {
            return items[0];
        }
        public T DeleteMax()
        {
            if (size <= 0)
                return default(T);

            if (size == 1)
            {
                size--;
                return items[0];
            }

            var del = items[0];
            swap(0, --size);
            MaxHeapify(0);

            return del;
        }

        public int Size()
        {
            return size;
        }

        private void MaxHeapify(int i)
        {
            int l = left(i);
            int r = right(i);
            int greatest = i;

            if (l < size && lesser(greatest, l))
                greatest = l;

            if (r < size && lesser(greatest, r))
                greatest = r;

            if (greatest != i)
            {
                swap(i, greatest);
                MaxHeapify(greatest);
            }
        }

        private void swap(int i, int j)
        {
            var temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        private int parent(int i)
        {
            return (i - 1) / 2;
        }

        private int left(int i)
        {
            return 2 * i + 1;
        }

        private int right(int i)
        {
            return 2 * i + 2;
        }

        private bool lesser(int i, int j)
        {
            return comparer.Compare(items[i], items[j]) < 0;
        }
    }
}
