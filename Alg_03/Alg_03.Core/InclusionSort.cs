using System;
using System.Collections.Generic;

namespace Alg_03.Core
{
    public class InclusionSort<T> : AbstractSort<T>
        where T : IComparable
    {
        public override void Sort(IList<T> array)
        {
            base.Sort(array);
            for (var i = 1; i < Array.Count; i++)
            {
                var value = Array[i];
                var index = i;
                while (index > 0 && Compare(Array[index - 1], value) > 0)
                {
                    AssignmentCount++;
                    Array[index] = Array[index - 1];
                    index--;
                }

                AssignmentCount++;
                Array[index] = value;
            }
        }
    }
}
