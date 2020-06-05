using System;

namespace Alg_07.Core
{
    public class Vertex<T> : Edges<T>, IComparable, IEquatable<Vertex<T>>
        where T : IComparable
    {
        public Vertex(T value) => Value = value;

        public T Value { get; }

        public int CompareTo(object obj)
        {
            var v = (Vertex<T>) obj;

            return Value.CompareTo(v.Value);
        }

        public bool Equals(Vertex<T>? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Value.CompareTo(other.Value) == 0;
        }

        public override string ToString() => $"{Value}";

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

            return Equals((Vertex<T>) obj);
        }

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(Vertex<T>? left, Vertex<T>? right) => Equals(left, right);

        public static bool operator !=(Vertex<T>? left, Vertex<T>? right) => !Equals(left, right);
    }
}
