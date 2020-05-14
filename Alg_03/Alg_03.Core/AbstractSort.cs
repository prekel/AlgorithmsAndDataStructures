using System;
using System.Collections.Generic;
using System.Collections;


namespace Alg_03.Core
{
    public abstract class AbstractSort
    {
        public int SwapCount { get; protected set; }
        public int CompareCount { get; protected set; }

        public IList<IComparable> Array { get; }
        protected AbstractSort(IList<IComparable> array) => Array = array;

        protected int Compare(IComparable a, IComparable b)
        {
            CompareCount++;
            return a.CompareTo(b);
        }

        public abstract void Sort();
    }
}
