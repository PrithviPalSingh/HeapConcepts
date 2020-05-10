using BinaryHeaps2017.Comparator;
using BinaryHeaps2017.Comparator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017.Problems
{
    class TopKFrequentWords
    {
        public static void fnTopKFrequentWords()
        {
            //string[] arr = new string[] { "geek", "i", "love", "leetcode", "i", "love", "coding", "geek" };
            //string[] arr = new string[] { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is", };
            string[] arr = new string[] { "i", "love", "leetcode", "i", "love", "coding" };
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int k = 3;
            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                    dict.Add(arr[i], 0);

                dict[arr[i]]++;
            }

            MinHeapRecurse<StringToCount> minHeap = new MinHeapRecurse<StringToCount>(k, new StringToCountComparer());

            foreach (var item in dict)
            {
                StringToCount sc = new StringToCount(item.Key, item.Value);
                if (minHeap.Size() == k)
                {
                    if (minHeap.Peek().count < sc.count
                        || (minHeap.Peek().count < sc.count && sc.str.CompareTo(minHeap.Peek().str) < 0))
                    {
                        minHeap.DeleteMin();
                    }
                }

                minHeap.Insert(sc);
            }

            List<string> strList = new List<string>();
            int l = minHeap.Size();
            while (l-- > 0)
            {
                strList.Add(minHeap.DeleteMin().str);
            }

            strList.Reverse();
            for (int i = 0; i < strList.Count; i++)
            {
                Console.Write(strList[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
