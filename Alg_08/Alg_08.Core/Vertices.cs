using System;
using System.Collections.Generic;

namespace Alg_08.Core
{
    public class Vertices<T> : SortedDictionary<T, Vertex<T>>
        where T : IComparable
    {
        public override string ToString() => String.Join("; ", Values);
    }
}
