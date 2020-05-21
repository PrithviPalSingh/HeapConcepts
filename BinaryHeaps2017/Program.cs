using BinaryHeaps2017.Comparator;
using BinaryHeaps2017.Comparator.Entities;
using BinaryHeaps2017.Problems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017
{
    class Program
    {
        static void Main(string[] args)
        {
            // MaxHeapTesting();
            /*KthLargest.kLargest();
            TopKFrequentWords.fnTopKFrequentWords();
            TopKFrequentNumbers.fnTopKFrequentNumbers();*/

            TestRemoveKDigits();

            //TopKFrequent();

            //TopKFrequentWords();

            //TopKFrequentNumbers();

            //List<int> l = new List<int>();
            //l.OrderByDescending(x => x);
            Console.Read();
        }

        private static void TopKFrequent()
        {
            string[] words = new string[] { "the", "day", "day", "day", "day", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is", };
            int k = 2;
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (!dict.ContainsKey(words[i]))
                {
                    dict.Add(words[i], 1);
                }
                else
                {
                    dict[words[i]]++;
                }
            }

            MinBinaryHeap<string> minHeap = new MinBinaryHeap<string>(k);
            int j = 0;
            foreach (var item in dict)
            {
                if (minHeap.N == k)
                {
                    var peek = minHeap.Peek();
                    if (item.Value > dict[peek])
                    {
                        minHeap.DeleteMin();
                        minHeap.Insert(item.Key);
                    }

                    continue;
                }

                minHeap.Insert(item.Key);
            }

            List<string> strList = new List<string>();
            int l = minHeap.N;
            while (l-- > 0)
            {
                strList.Add(minHeap.DeleteMin());
            }

            for (int i = 0; i < strList.Count; i++)
            {
                Console.Write(strList[i] + " ");
            }
        }       

        private static void MaxHeapTesting()
        {
            MaxBinaryHeap<int> maxHeap = new MaxBinaryHeap<int>(6);
            int[] arr = new int[] { 12, 11, 13, 5, 6, 7, 50, 49, 1 };

            for (int i = 0; i < 6; i++)
            {
                maxHeap.Insert(arr[i]);
            }

            for (int i = 6; i < arr.Length; i++)
            {
                if (maxHeap.Peek() < arr[i])
                {
                    maxHeap.DeleteMax();
                    maxHeap.Insert(arr[i]);
                }
            }

            //minHeap.Insert(12);
            //minHeap.Insert(11);
            //minHeap.Insert(13);
            //minHeap.Insert(5);
            //minHeap.Insert(6);
            //minHeap.Insert(7);
            //minHeap.Insert(50);
            //minHeap.Insert(49);
            //minHeap.Insert(1);
        }

        private static void MinHeapTesting()
        {
            MinBinaryHeap<int> minHeap = new MinBinaryHeap<int>(6);
            int[] arr = new int[] { 12, 11, 13, 5, 6, 7, 50, 49, 1 };

            for (int i = 0; i < 6; i++)
            {
                minHeap.Insert(arr[i]);
            }

            for (int i = 6; i < arr.Length; i++)
            {
                if (minHeap.Peek() > arr[i])
                {
                    minHeap.DeleteMin();
                    minHeap.Insert(arr[i]);
                }
            }

            //minHeap.Insert(12);
            //minHeap.Insert(11);
            //minHeap.Insert(13);
            //minHeap.Insert(5);
            //minHeap.Insert(6);
            //minHeap.Insert(7);
            //minHeap.Insert(50);
            //minHeap.Insert(49);
            //minHeap.Insert(1);
        }

        private static void TestRemoveKDigits()
        {
            string s = "1432519";
            int k = 3;

            Console.WriteLine(RemoveKDigits.fnRemoveKdigits(s, k));
        }
    }    

    

    

    

    
}
