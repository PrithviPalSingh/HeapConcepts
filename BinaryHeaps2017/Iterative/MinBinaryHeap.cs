using System;

namespace BinaryHeaps2017
{
    class MinBinaryHeap<T> where T : IComparable<T>
    {
        private T[] Items;

        private int n;

        public int N { get => n; set => n = value; }

        public MinBinaryHeap(int n)
        {
            Items = new T[n + 1];
        }

        public void Insert(T a)
        {
            Items[++N] = a;
            Swim(N);
        }

        private void Swim(int k)
        {
            while (k > 1 && greater(k / 2, k))
            {
                Exchange(k, k / 2);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && greater(j, j + 1))
                {
                    j++;
                }

                if (greater(j, k))
                { break; }

                Exchange(k, j);
                k = j;
            }
        }

        public T DeleteMin()
        {
            T min = Items[1];
            Exchange(1, N--);
            Sink(1);
            Items[N + 1] = default(T);
            return min;
        }

        public T Peek()
        {
            return Items[1];
        }

        private bool greater(int i, int j)
        {
            return Items[i].CompareTo(Items[j]) > 0;
        }

        private void Exchange(int i, int j)
        {
            var swap = Items[i];
            Items[i] = Items[j];
            Items[j] = swap;
        }
    }
}
