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
                var index = i;
                while (index > 0 && Compare(List[index - 1], value) > 0)
                {
                    AssignmentCount++;
                    List[index] = List[index - 1];
                    index--;
                }

                AssignmentCount++;
                List[index] = value;
            }
        }
    }
}
