using BinaryHeaps2017.Comparator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeaps2017.Problems
{
    class RemoveKDigits
    {
        public static string fnRemoveKdigits(string num, int k)
        {
            if (string.IsNullOrEmpty(num) || num.Length < k)
                return string.Empty;

            MinHeapRecurse<int> mh = new MinHeapRecurse<int>(k, new IntComparer());

            for (int i = 0; i < num.Length; i++)
            {
                if (k == mh.Size())
                {
                    if ((num[i] - '0') > mh.Peek())
                        mh.DeleteMin();
                }

                mh.Insert(num[i] - '0');
            }

            HashSet<int> hs = new HashSet<int>();
            while (mh.Size() > 0)
            {
                var del = mh.DeleteMin();
                hs.Add(del);
            }

            StringBuilder sb = new StringBuilder();
            for (int j = num.Length - 1; j >= 0; j--)
            {
                if (!hs.Contains(num[j] - '0'))
                {
                    sb.Append(num[j]);
                }
                else
                {
                    hs.Remove(num[j] - '0');
                }
            }
            
            var list = sb.ToString().Reverse().ToArray();
            list.Reverse();
            return new string(list);
        }
    }
}
