using System;
using System.Collections.Generic;

namespace Alg_03.Core
{
    public class SelectionSort<T> : AbstractSort<T>
        where T : IComparable
    {
        public override void Sort(IList<T> list)
        {
            base.Sort(list);
            for (var i = 0; i < List.Count - 1; i++)
            {
                var min = i;

                for (var j = i + 1; j < List.Count; j++)
                {
                    if (Compare(List[j], List[min]) < 0)
                    {
                        min = j;
                    }
                }

                AssignmentCount += 2;
                var temp = List[i];
                List[i] = List[min];
                List[min] = temp;
            }
        }
    }
}
