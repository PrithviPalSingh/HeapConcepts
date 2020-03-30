using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017
{
    class MinHeapRecurse
    {
        int[] items;
        int capacity;
        int size;

        public MinHeapRecurse(int cap)
        {
            this.items = new int[cap];
            this.capacity = cap;
            this.size = 0;
        }

        public void Insert(int val)
        {
            if (capacity == size)
            {
                Console.WriteLine("Cannot insert");
                return;
            }

            size++;
            int i = size - 1;
            items[i] = val;

            while (i != 0 && items[parent(i)] > items[i])
            {
                swap(i, parent(i));
                i = parent(i);
            }
        }

        void deleteKey(int i)
        {
            if (size <= 0 || i > size - 1)
                return;

            DecreaseKey(i, int.MinValue);
            DeleteMin();
        }

        public void DecreaseKey(int i, int new_val)
        {
            items[i] = new_val;
            while (i != 0 && items[parent(i)] > items[i])
            {
                swap(i, parent(i));
                i = parent(i);
            }
        }

        public int Peek()
        {
            return items[0];
        }
        public int DeleteMin()
        {
            if (size <= 0)
                return int.MinValue;

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

            if (l < size && items[l] < items[smallest])
                smallest = l;

            if (r < size && items[r] < items[smallest])
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

    }
}
