using System;
using System.Collections.Generic;

namespace Alg_03.Core
{
    public class SelectionSort : AbstractSort
    {
        public SelectionSort(IList<IComparable> array) : base(array)
        {
        }

        public override void Sort()
        {
            int min;
            for (var i = 0; i < Array.Count - 1; i++)
            {
                min = i;

                for (var j = i + 1; j < Array.Count; j++)
                {
                    if (Compare(Array[j], Array[min]) > 0)
                    {
                        min = j;
                    }
                }

                AssignmentCount += 2;
                var temp = Array[i];
                Array[i] = Array[min];
                Array[min] = temp;
            }
        }
    }
}
