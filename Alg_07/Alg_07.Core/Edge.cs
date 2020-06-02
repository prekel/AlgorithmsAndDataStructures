using System;

namespace Alg_07.Core
{
    public class Edge<T> : Tuple<Vertex<T>, Vertex<T>>, IComparable, IEquatable<Edge<T>>
        where T : IComparable
    {
        public Edge(Vertex<T> item1, Vertex<T> item2, double weight) : base(item1, item2)
        {
            Weight = weight;
        }

        public double Weight { get; }

        public int CompareTo(object obj)
        {
            var (item1, item2) = (Edge<T>) obj;

            var c1 = Item1.CompareTo(item1);
            var c2 = Item2.CompareTo(item2);

            return c1 == 0 ? c2 : c1;
        }

        public bool Equals(Edge<T>? other) =>
            other != null && Item1.Equals(other.Item1) && Item2.Equals(other.Item2);

        public bool HasVertex(Vertex<T> v) => Item1 == v || Item2 == v;

        public Vertex<T>? OtherVertex(Vertex<T> v) => v == Item1 ? Item2 : v == Item2 ? Item1 : null;

        public override string ToString() => $"{Item1} - {Item2}";

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
