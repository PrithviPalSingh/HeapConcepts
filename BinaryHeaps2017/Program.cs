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
            //kLargest();

            //TopKFrequent();

            TopKFrequentWords();

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

        private static void kLargest()
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

        private static void TopKFrequentWords()
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
        }

        public static IList<int> TopKFrequentNumbers()
        {
            int[] nums = new int[] { 6, 0, 1, 4, 9, 7, -3, 1, -4, -8, 4, -7, -3, 3, 2, -3, 9, 5, -4, 0 };
            int k = 6;
            IList<int> list = new List<int>();
            if (nums == null || nums.Length == 0)
                return list;

            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], 0);

                dict[nums[i]]++;
            }

            MinHeapRecurse<NumToCount> minHeap = new MinHeapRecurse<NumToCount>(k, new NumToCountComparer());

            foreach (var item in dict)
            {
                NumToCount nc = new NumToCount(item.Key, item.Value);
                if (minHeap.Size() == k)
                {
                    if (minHeap.Peek().count < nc.count)
                    {
                        minHeap.DeleteMin();
                    }
                }

                minHeap.Insert(nc);
            }

            int l = minHeap.Size();
            while (l-- > 0)
            {
                list.Add(minHeap.DeleteMin().number);
            }
            var s = list.ToArray();
            return list;
        }
    }

    public class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y)
                return 1;
            else if (x < y)
                return -1;
            else
                return 0;
        }
    }

    class NumToCountComparer : IComparer<NumToCount>
    {
        public int Compare(NumToCount x, NumToCount y)
        {
            if (x.count > y.count)
                return 1;
            else if (x.count < y.count)
                return -1;
            else
                return 0;
        }
    }

    class StringToCountComparer : IComparer<StringToCount>
    {
        public int Compare(StringToCount x, StringToCount y)
        {
            if (x.count > y.count)
                return 1;
            else if (x.count < y.count)
                return -1;
            else
            {
                return y.str.CompareTo(x.str);
            }                
        }
    }

    class StringToCount
    {
        public string str;
        public int count;

        // A parameterized student constructor 
        public StringToCount(string s, int c)
        {

            this.str = s;
            this.count = c;
        }
    }

    class NumToCount
    {
        public int number;
        public int count;

        // A parameterized student constructor 
        public NumToCount(int num, int c)
        {

            this.number = num;
            this.count = c;
        }
    }
}
