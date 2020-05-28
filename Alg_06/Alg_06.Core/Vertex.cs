namespace Alg_06.Core
{
    public class Vertex<T> : Edges<T>
    {
        public Vertex(T value) => Value = value;

        public T Value { get; }

        public override string ToString() => $"{Value}";
    }
}
