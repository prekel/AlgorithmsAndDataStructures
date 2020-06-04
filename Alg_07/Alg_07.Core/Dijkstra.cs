using System;
using System.Collections.Generic;
using System.Linq;

namespace Alg_07.Core
{
    public class Dijkstra<T>
        where T : IComparable
    {
        public Dijkstra(Graph<T> g, Vertex<T> a)
        {
            G = g;
            this.a = a;
        }

        public Graph<T> G { get; }
        public Vertices<T> V => G.V;
        public Edges<T> E => G.E;
        public Vertex<T> a { get; }

        private SortedSet<Vertex<T>> U { get; } = new SortedSet<Vertex<T>>();
        private SortedDictionary<Vertex<T>, double> d { get; } = new SortedDictionary<Vertex<T>, double>();

        private SortedDictionary<Vertex<T>, List<Edge<T>>> p { get; } =
            new SortedDictionary<Vertex<T>, List<Edge<T>>>();

        public void Calc()
        {
            d[a] = 0;
            p[a] = new List<Edge<T>>();
            foreach (var u in V.Where(y => y.Value != a).Select(y => y.Value))
            {
                d[u] = Double.PositiveInfinity;
            }

            while (U.Count < V.Count)
            {
                var v = V.Select(y => y.Value)
                    .Except(U)
                    .OrderBy(y => d[y])
                    .First();
                U.Add(v);
                foreach (var u in V.Select(y => y.Value)
                    .Except(U)
                    .Where(u => v.Contains(E.FirstOrDefault(e => e.Item1 == v && e.Item2 == u))))
                {
                    var vu = E.First(e => e.Item1 == v && e.Item2 == u);
                    if (d[u] > d[v] + vu.Weight)
                    {
                        d[u] = d[v] + vu.Weight;
                        p[u] = new List<Edge<T>>(p[v]) {vu};
                    }
                }
            }
        }
    }
}
