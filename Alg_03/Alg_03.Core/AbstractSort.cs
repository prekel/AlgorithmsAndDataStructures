using System;
using System.Collections.Generic;
using System.Collections;


namespace Alg_03.Core
{
    public abstract class AbstractSort<T>
        where T : IComparable
    {
        public int AssignmentCount { get; protected set; }
        public int CompareCount { get; protected set; }

        public IList<T> Array { get; }
        protected AbstractSort(IList<T> array) => Array = array;

        protected int Compare(IComparable a, IComparable b)
        {
            CompareCount++;
            return a.CompareTo(b);
        }

        public abstract void Sort();
    }
}
