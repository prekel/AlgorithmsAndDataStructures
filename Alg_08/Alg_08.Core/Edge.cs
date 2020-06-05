using System;

namespace Alg_08.Core
{
    public class Edge<T> : Tuple<Vertex<T>, Vertex<T>>, IComparable, IEquatable<Edge<T>>
        where T : IComparable
    {
        public Edge(Vertex<T> item1, Vertex<T> item2, double weight) : base(item1, item2) => Weight = weight;

        public double Weight { get; }

        public Vertex<T> LessVertex => Item1.CompareTo(Item2) > 0 ? Item2 : Item1;
        public Vertex<T> GreatVertex => Item1.CompareTo(Item2) > 0 ? Item1 : Item2;

        public int CompareTo(object obj)
        {
            var e = (Edge<T>) obj;

            var c1 = LessVertex.CompareTo(e.LessVertex);
            var c2 = GreatVertex.CompareTo(e.GreatVertex);

            return c1 == 0 ? c2 : c1;
        }

        public bool Equals(Edge<T>? other) =>
            other != null && LessVertex.Equals(other.LessVertex) && GreatVertex.Equals(other.GreatVertex);

        public bool HasVertex(Vertex<T> v) => Item1 == v || Item2 == v;

        public Vertex<T>? OtherVertex(Vertex<T> v) => v == Item1 ? Item2 : v == Item2 ? Item1 : null;

        public override string ToString() => $"({Item1} <-{Weight}-> {Item2})";

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Edge<T>) obj);
        }

        public override int GetHashCode() => base.GetHashCode();

        public static bool operator ==(Edge<T>? left, Edge<T>? right) => Equals(left, right);

        public static bool operator !=(Edge<T>? left, Edge<T>? right) => !Equals(left, right);
    }
}
