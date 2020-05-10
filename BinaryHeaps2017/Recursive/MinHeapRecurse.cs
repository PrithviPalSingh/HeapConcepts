using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017
{
    class MinHeapRecurse<T> //where T : IComparable<T>
    {
        T[] items;
        int capacity;
        int size;
        IComparer<T> comparer;

        public MinHeapRecurse(int cap, IComparer<T> comp)
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
                return;
            }

            size++;
            int i = size - 1;
            items[i] = val;

            while (i != 0 && greater(parent(i), i))
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
            DeleteMin();
        }

        public void DecreaseKey(int i, T new_val)
        {
            items[i] = new_val;
            while (i != 0 && greater(parent(i), i))
            {
                swap(i, parent(i));
                i = parent(i);
            }
        }

        public T Peek()
        {
            return items[0];
        }
        public T DeleteMin()
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
            MinHeapify(0);

            return del;
        }

        public int Size()
        {
            return size;
        }

        private void MinHeapify(int i)
        {
            int l = left(i);
            int r = right(i);
            int smallest = i;

            if (l < size && greater(smallest, l))
                smallest = l;

            if (r < size && greater(smallest, r))
                smallest = r;

            if (smallest != i)
            {
                swap(i, smallest);
                MinHeapify(smallest);
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
        
        private bool greater(int i, int j)
        {
            return comparer.Compare(items[i], items[j]) > 0;
            //return items[i].CompareTo(items[j]) > 0;
        }
    }
}
