using BinaryHeaps2017.Comparator;
using BinaryHeaps2017.Comparator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017.Problems
{
    class TopKFrequentNumbers
    {
        public static void fnTopKFrequentNumbers()
        {
            int[] nums = new int[] { 6, 0, 1, 4, 9, 7, -3, 1, -4, -8, 4, -7, -3, 3, 2, -3, 9, 5, -4, 0 };
            int k = 6;
            IList<int> list = new List<int>();
            if (nums == null || nums.Length == 0)
                return ;

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

            list.Reverse();
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
