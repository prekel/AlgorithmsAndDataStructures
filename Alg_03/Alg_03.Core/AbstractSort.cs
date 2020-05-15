using System;
using System.Collections.Generic;

namespace Alg_03.Core
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

        public IList<T> List { get; private set; } = new List<T>();

        public SortOrder Order { get; set; } = SortOrder.Ascending;

        protected int Compare(IComparable a, IComparable b)
        {
            CompareCount++;
            return (int) Order * a.CompareTo(b);
        }

        public virtual void Sort(IList<T> list)
        {
            List = list;
            AssignmentCount = 0;
            CompareCount = 0;
        }
    }
}
