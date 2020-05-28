using System;
using System.Collections.Generic;

namespace Alg_06.Core
{
    public class Graph<T> : Tuple<Vertices<T>, Edges<T>>
    {
        public Graph() : base(new Vertices<T>(), new Edges<T>())
        {
        }

        public Vertices<T> V => Item1;
        public Edges<T> E => Item2;

        public Vertex<T> AddVertex(T value)
        {
            V[value] = new Vertex<T>(value);
            return V[value];
        }

        public Edge<T> AddEdge(T value1, T value2)
        {
            var e = new Edge<T>(V[value1], V[value2]);
            E.Add(e);
            V[value1].Add(e);
            V[value2].Add(e);
            return e;
        }

        public void Dfs(Vertex<T> v, Action<Vertex<T>> action)
        {
            var visited = new Dictionary<Vertex<T>, bool>();
            Dfs(v, action, visited);
        }

        private static void Dfs(Vertex<T> v, Action<Vertex<T>> action, IDictionary<Vertex<T>, bool> visited)
        {
            visited[v] = true;
            action.Invoke(v);
            foreach (var (vertex1, vertex2) in v)
            {
                var next = vertex1 == v ? vertex2 : vertex1;
                if (visited.ContainsKey(next) && visited[next])
                {
                    continue;
                }

                Dfs(next, action, visited);
            }
        }
    }
}
