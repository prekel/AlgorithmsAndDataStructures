using System;
using System.Collections.Generic;

namespace Alg_07.Core
{
    public class Edges<T> : SortedSet<Edge<T>>
        where T : IComparable
    {
        public override string ToString() => String.Join("; ", this);
    }
}
