using System;
using System.Collections.Generic;

namespace Alg_07.Core
{
    public class Vertices<T> : SortedDictionary<T, Vertex<T>>
        where T : IComparable
    {
        public override string ToString() => String.Join("; ", Values);
    }
}
