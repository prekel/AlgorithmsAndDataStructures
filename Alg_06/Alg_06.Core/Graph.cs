using System;
using System.Collections.Generic;
using System.Linq;

namespace Alg_06.Core
{
    public class Graph<T> : Tuple<Vertices<T>, Edges<T>>
        where T : IComparable
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

        public void RemoveVertex(T value)
        {
            E.RemoveWhere(e => e.HasVertex(V[value]));
            V.Remove(value);
        }

        public void RemoveVertex(Vertex<T> v)
        {
            E.RemoveWhere(e => e.HasVertex(v));
            V.Remove(v.Value);
        }

        public void RemoveEdge(Edge<T> e)
        {
            V[e.Item1.Value].RemoveWhere(ed => ed.CompareTo(e) == 0);
            V[e.Item2.Value].RemoveWhere(ed => ed.CompareTo(e) == 0);
            E.RemoveWhere(ed => ed.CompareTo(e) == 0);
        }

        public void RemoveEdge(T value1, T value2)
        {
            var v1 = V[value1];
            var v2 = V[value2];
            v1.RemoveWhere(ed => ed.HasVertex(v1) && ed.HasVertex(v2));
            v2.RemoveWhere(ed => ed.HasVertex(v1) && ed.HasVertex(v2));
            E.RemoveWhere(ed => ed.HasVertex(v1) && ed.HasVertex(v2));
        }

        public Edge<T> AddEdge(T value1, T value2) => AddEdge(V[value1], V[value2]);

        public Edge<T> AddEdge(Vertex<T> v1, Vertex<T> v2)
        {
            var e = new Edge<T>(v1, v2);
            E.Add(e);
            v1.Add(e);
            v2.Add(e);
            return e;
        }

        public void Dfs(T value, Action<Vertex<T>> action) => Dfs(V[value], action);

        public void Dfs(Vertex<T> v, Action<Vertex<T>> action) =>
            Dfs(v, action, new SortedDictionary<Vertex<T>, bool>());

        private static void Dfs(Vertex<T> v, Action<Vertex<T>> action, IDictionary<Vertex<T>, bool> visited)
        {
            visited[v] = true;
            action.Invoke(v);
            foreach (var next in UnvisitedVertices(v, visited))
            {
                Dfs(next, action, visited);
            }
        }

        public void Bfs(T value, Action<Vertex<T>> action) => Bfs(V[value], action);

        public void Bfs(Vertex<T> v, Action<Vertex<T>> action) =>
            Bfs(v, action, new SortedDictionary<Vertex<T>, bool>());

        private static void Bfs(Vertex<T> v, Action<Vertex<T>> action, IDictionary<Vertex<T>, bool> visited)
        {
            var queue = new Queue<Vertex<T>>();
            visited[v] = true;
            queue.Enqueue(v);
            while (queue.Count > 0)
            {
                var cv = queue.Dequeue();
                action.Invoke(cv);
                foreach (var next in UnvisitedVertices(cv, visited))
                {
                    visited[next] = true;
                    queue.Enqueue(next);
                }
            }
        }

        private static IEnumerable<Vertex<T>> UnvisitedVertices(Vertex<T> cv, IDictionary<Vertex<T>, bool> visited)
        {
            return cv
                .Select(i => i.OtherVertex(cv) ?? cv)
                .Where(next => !visited.ContainsKey(next) || !visited[next]);
        }


        public override string ToString() => $"V: {String.Join(", ", V.Values)}; E: {String.Join(", ", E)}";
    }
}
