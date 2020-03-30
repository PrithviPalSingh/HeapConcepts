using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017
{
    class MaxBinaryHeapRecurse
    {
        int[] items;
        int capacity;
        int size;

        public MaxBinaryHeapRecurse(int cap)
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

            while (i != 0 && items[parent(i)] < items[i])
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
            DeleteMax();
        }

        public void DecreaseKey(int i, int new_val)
        {
            items[i] = new_val;
            while (i != 0 && items[parent(i)] < items[i])
            {
                swap(i, parent(i));
                i = parent(i);
            }
        }

        public int Peek()
        {
            return items[0];
        }
        public int DeleteMax()
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
            MaxHeapify(0);

            return del;
        }

        private void MaxHeapify(int i)
        {
            int l = left(i);
            int r = right(i);
            int greatest = i;

            if (l < size && items[l] > items[greatest])
                greatest = l;

            if (r < size && items[r] > items[greatest])
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
    }
}
