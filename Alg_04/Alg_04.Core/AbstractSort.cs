using System;
using System.Collections.Generic;

namespace Alg_04.Core
{
    public abstract class AbstractSort<T>
        where T : IComparable
    {
        public enum SortOrder
        {
            Ascending = 1,
            Descending = -1
        }

        public int AssignmentCount { get; protected set; }
        public int CompareCount { get; protected set; }

        public SortOrder Order { get; set; } = SortOrder.Ascending;

        protected int Compare(T a, T b)
        {
            CompareCount++;
            return (int) Order * a.CompareTo(b);
        }

        public virtual void Sort(IList<T> list)
        {
            AssignmentCount = 0;
            CompareCount = 0;
        }
    }
}
