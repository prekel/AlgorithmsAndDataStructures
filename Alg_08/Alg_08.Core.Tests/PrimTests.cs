using NUnit.Framework;

namespace Alg_08.Core.Tests
{
    public class PrimTests
    {
        [Test]
        public void TestFromWiki1()
        {
            var g = new Graph<int>();
            g.AddVertex(1);
            g.AddVertex(2);
            g.AddVertex(3);
            g.AddVertex(4);
            g.AddVertex(5);
            g.AddVertex(6);
            g.AddVertex(7);
            g.AddVertex(8);
            g.AddVertex(9);
            g.AddVertex(10);
            g.AddEdge(1, 2, 9);
            g.AddEdge(1, 3, 3);
            g.AddEdge(1, 4, 6);
            g.AddEdge(2, 3, 9);
            g.AddEdge(2, 5, 8);
            g.AddEdge(2, 9, 18);
            g.AddEdge(3, 4, 4);
            g.AddEdge(3, 10, 2);
            g.AddEdge(3, 5, 9);
            g.AddEdge(4, 10, 2);
            g.AddEdge(4, 6, 9);
            g.AddEdge(5, 10, 8);
            g.AddEdge(5, 6, 7);
            g.AddEdge(5, 8, 9);
            g.AddEdge(5, 9, 10);
            g.AddEdge(6, 10, 9);
            g.AddEdge(6, 7, 4);
            g.AddEdge(6, 8, 5);
            g.AddEdge(7, 8, 1);
            g.AddEdge(7, 9, 4);
            g.AddEdge(8, 9, 3);

            var p = new Prim<int>(g);
            p.Calc();

            Assert.That(p.MstWeight, Is.EqualTo(38));
        }
    }
}
