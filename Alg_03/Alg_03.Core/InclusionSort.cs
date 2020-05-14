using System;
using System.Collections.Generic;

namespace Alg_03.Core
{
    public class InclusionSort : AbstractSort
    {
        public InclusionSort(IList<IComparable> array) : base(array)
        {
        }

        public override void Sort()
        {
            for (var i = 1; i < Array.Count; i++)
            {
                var value = Array[i];
                var index = i;
                while (index > 0 && Compare(Array[index - 1], value) > 0)
                {
                    SwapCount++;
                    Array[index] = Array[index - 1];
                    index--;
                }

                SwapCount++;
                Array[index] = value;
            }
        }
    }
}
