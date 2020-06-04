using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Alg_08.Core
{
    public class Prim<T>
        where T : IComparable
    {
        public readonly Edges<T> Mst = new Edges<T>();

        public Prim(Graph<T> g)
        {
            G = g;
            Q = new SortedDictionary<T, Vertex<T>>(V);
        }

        public double MstWeight => Mst.Select(e => e.Weight).Sum();

        public Graph<T> G { get; }
        private Vertices<T> V => G.V;
        private Edges<T> E => G.E;

        private SortedDictionary<Vertex<T>, double> d { get; } = new SortedDictionary<Vertex<T>, double>();
        private SortedDictionary<Vertex<T>, Vertex<T>?> p { get; } = new SortedDictionary<Vertex<T>, Vertex<T>?>();

        private SortedDictionary<T, Vertex<T>> Q { get; }
        private double w(Vertex<T> i, Vertex<T> j) => E.First(e => e.HasVertex(i) && e.HasVertex(j)).Weight;

        public void Calc()
        {
            foreach (var i in V.Select(pair => pair.Value))
            {
                d[i] = Double.PositiveInfinity;
                p[i] = null;
            }

            d[V.Select(y => y.Value).First()] = 0;

            var v = Q.OrderBy(i => d[i.Value]).First().Value;
            Q.Remove(v.Value);

            while (Q.Count > 0)
            {
                foreach (var u in v.Select(e => e.OtherVertex(v)))
                {
                    if (u == null)
                    {
                        Debugger.Break();
                        continue;
                    }

                    if (Q.ContainsValue(u) && w(v, u) < d[u])
                    {
                        d[u] = w(v, u);
                        p[u] = v;
                    }
                }

                v = Q.OrderBy(i => d[i.Value]).First().Value;
                Q.Remove(v.Value);
                Mst.Add(E.First(e => e.HasVertex(p[v] ?? v) && e.HasVertex(v)));
            }
        }
    }
}
