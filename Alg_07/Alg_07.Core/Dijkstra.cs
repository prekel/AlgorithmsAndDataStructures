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
            A = a;
        }

        public Graph<T> G { get; }
        public Vertex<T> A { get; }
        public SortedDictionary<Vertex<T>, double> Distances { get; } = new SortedDictionary<Vertex<T>, double>();

        public SortedDictionary<Vertex<T>, List<Edge<T>>> Paths { get; } =
            new SortedDictionary<Vertex<T>, List<Edge<T>>>();

        private Vertices<T> V => G.V;
        private Edges<T> E => G.E;
        private SortedSet<Vertex<T>> U { get; } = new SortedSet<Vertex<T>>();

        public void Calc()
        {
            Distances[A] = 0;
            Paths[A] = new List<Edge<T>>();
            foreach (var u in V.Where(y => y.Value != A).Select(y => y.Value))
            {
                Distances[u] = Double.PositiveInfinity;
            }

            while (U.Count < V.Count)
            {
                var v = V.Select(y => y.Value)
                    .Except(U)
                    .OrderBy(y => Distances[y])
                    .First();
                U.Add(v);
                foreach (var u in V.Select(y => y.Value)
                    .Except(U)
                    .Where(u => v.Contains(E.FirstOrDefault(e => e.Item1 == v && e.Item2 == u))))
                {
                    var vu = E.First(e => e.Item1 == v && e.Item2 == u);
                    if (Distances[u] > Distances[v] + vu.Weight)
                    {
                        Distances[u] = Distances[v] + vu.Weight;
                        Paths[u] = new List<Edge<T>>(Paths[v]) {vu};
                    }
                }
            }
        }
    }
}
