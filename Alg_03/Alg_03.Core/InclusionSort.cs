using System;
using System.Collections.Generic;

namespace Alg_03.Core
{
    public class InclusionSort<T> : AbstractSort<T>
        where T : IComparable
    {
        public override void Sort(IList<T> list)
        {
            base.Sort(list);
            for (var i = 1; i < List.Count; i++)
            {
                var value = List[i];
                var j = i;
                while (j > 0 && Compare(List[j - 1], value) > 0)
                {
                    AssignmentCount++;
                    List[j] = List[j - 1];
                    j--;
                }

                AssignmentCount++;
                List[j] = value;
            }
        }
    }
}
