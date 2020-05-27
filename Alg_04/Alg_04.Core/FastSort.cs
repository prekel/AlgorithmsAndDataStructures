using System;
using System.Collections.Generic;

namespace Alg_04.Core
{
    public class FastSort<T> : AbstractSort<T>
        where T : IComparable
    {
        public override void Sort(IList<T> list)
        {
            base.Sort(list);
            Sort(list, 0, list.Count - 1);
        }

        private void Sort(IList<T> list, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            var p = Partition(list, left, right);

            var s1 = new FastSort<T> {Order = Order};
            s1.Sort(list, left, p);
            CompareCount += s1.CompareCount;
            AssignmentCount += s1.AssignmentCount;

            var s2 = new FastSort<T> {Order = Order};
            s2.Sort(list, p + 1, right);
            CompareCount += s2.CompareCount;
            AssignmentCount += s2.AssignmentCount;
        }

        private int Partition(IList<T> list, int left, int right)
        {
            var temp = list[(left + right) / 2];

            var i = left;
            var j = right;

            while (i <= j)
            {
                while (Compare(list[i], temp) < 0)
                {
                    i++;
                }

                while (Compare(list[j], temp) > 0)
                {
                    j--;
                }

                if (i >= j)
                {
                    break;
                }

                AssignmentCount += 2;
                var temp1 = list[i];
                list[i] = list[j];
                list[j] = temp1;
                i++;
                j--;
            }

            return j;
        }
    }
}
