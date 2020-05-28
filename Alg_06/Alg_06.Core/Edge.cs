using System;

namespace Alg_06.Core
{
    public class Edge<T> : Tuple<Vertex<T>, Vertex<T>>
    {
        public Edge(Vertex<T> item1, Vertex<T> item2) : base(item1, item2)
        {
        }
    }
}
