using BinaryHeaps2017.Comparator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017.Problems
{
    class KthLargest
    {
        public static void kLargest()
        {
            int t = 1;
            while (t-- > 0)
            {
                int[] sizeAndLength = new int[] { 8, 3 };
                int[] array = Array.ConvertAll("1 23 12 90 100 30 2 50".Split(' '), int.Parse);
                MinHeapRecurse<int> minHeap = new MinHeapRecurse<int>(sizeAndLength[1], new IntComparer());
                for (int i = 0; i < sizeAndLength[1]; i++)
                {
                    minHeap.Insert(array[i]);
                }

                for (int i = sizeAndLength[1]; i < sizeAndLength[0]; i++)
                {
                    if (minHeap.Peek() < array[i])
                    {
                        minHeap.DeleteMin();
                        minHeap.Insert(array[i]);
                    }
                }

                List<int> list = new List<int>();
                for (int i = 0; i < sizeAndLength[1]; i++)
                {
                    list.Add(minHeap.DeleteMin());
                }

                list.Reverse();
                for (int i = 0; i < list.Count; i++)
                {
                    Console.Write(list[i] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
