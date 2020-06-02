using System;
using System.Collections.Generic;
using System.Linq;

namespace Alg_07.Core
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

        public Edge<T> AddEdge(T value1, T value2, double weigth) => AddEdge(V[value1], V[value2], weigth);

        public Edge<T> AddEdge(Vertex<T> v1, Vertex<T> v2, double weigth)
        {
            var e = new Edge<T>(v1, v2, weigth);
            E.Add(e);
            v1.Add(e);
            v2.Add(e);
            return e;
        }
        
        public override string ToString() => $"V: {String.Join(", ", V.Values)}; E: {String.Join(", ", E)}";
    }
}
