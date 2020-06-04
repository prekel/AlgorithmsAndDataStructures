using NUnit.Framework;

namespace Alg_07.Core.Tests
{
    public class DijkstraTests
    {
        [Test]
        public void TestFromWiki()
        {
            var g = new Graph<int>();
            g.AddVertex(1);
            g.AddVertex(2);
            g.AddVertex(3);
            g.AddVertex(4);
            g.AddVertex(5);
            g.AddVertex(6);
            g.AddEdge(1, 2, 7);
            g.AddEdge(2, 1, 7);
            g.AddEdge(1, 3, 9);
            g.AddEdge(3, 1, 9);
            g.AddEdge(1, 6, 14);
            g.AddEdge(6, 1, 14);
            g.AddEdge(2, 3, 10);
            g.AddEdge(3, 2, 10);
            g.AddEdge(2, 4, 15);
            g.AddEdge(4, 2, 15);
            g.AddEdge(3, 6, 2);
            g.AddEdge(6, 3, 2);
            g.AddEdge(6, 5, 9);
            g.AddEdge(5, 6, 9);
            g.AddEdge(5, 4, 6);
            g.AddEdge(4, 5, 6);

            var d = new Dijkstra<int>(g, g.V[1]);
            d.Calc();
        }
    }
}
