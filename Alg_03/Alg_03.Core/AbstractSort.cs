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

        public IList<T> List { get; private set; } = new List<T>();

        protected int Compare(IComparable a, IComparable b)
        {
            CompareCount++;
            return a.CompareTo(b);
        }

        public virtual void Sort(IList<T> list)
        {
            List = list;
            AssignmentCount = 0;
            CompareCount = 0;
        }
    }
}
