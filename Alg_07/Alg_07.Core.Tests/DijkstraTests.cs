using System;
using System.Linq;

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
            g.AddEdge(1, 3, 9);
            g.AddEdge(1, 6, 14);
            g.AddEdge(2, 3, 10);
            g.AddEdge(2, 4, 15);
            g.AddEdge(3, 6, 2);
            g.AddEdge(3, 4, 11);
            g.AddEdge(6, 5, 9);
            g.AddEdge(5, 4, 6);
            g.AddEdge(2, 1, 7);
            g.AddEdge(3, 1, 9);
            g.AddEdge(6, 1, 14);
            g.AddEdge(3, 2, 10);
            g.AddEdge(4, 2, 15);
            g.AddEdge(6, 3, 2);
            g.AddEdge(4, 3, 11);
            g.AddEdge(5, 6, 9);
            g.AddEdge(4, 5, 6);

            var d = new Dijkstra<int>(g, g.V[1]);
            d.Calc();

            Assert.That(d.Distances.Count, Is.EqualTo(6));
            Assert.That(d.Distances.Select(p => p.Value), Is.EquivalentTo(new[] {0, 7, 9, 20, 20, 11}));
            Assert.That(d.Paths[g.V[5]],
                Is.EquivalentTo(new[]
                {
                    g.E.First(e => e.Item1.Value == 1 && e.Item2.Value == 3),
                    g.E.First(e => e.Item1.Value == 3 && e.Item2.Value == 6),
                    g.E.First(e => e.Item1.Value == 6 && e.Item2.Value == 5)
                }));
        }

        [Test]
        public void TestFromWikiWithNonConnectivity()
        {
            var g = new Graph<int>();
            g.AddVertex(1);
            g.AddVertex(2);
            g.AddVertex(3);
            g.AddVertex(4);
            g.AddVertex(5);
            g.AddVertex(6);
            g.AddEdge(1, 2, 7);
            g.AddEdge(1, 3, 9);
            g.AddEdge(1, 6, 14);
            g.AddEdge(2, 3, 10);
            g.AddEdge(2, 4, 15);
            g.AddEdge(3, 6, 2);
            g.AddEdge(3, 4, 11);
            g.AddEdge(6, 5, 9);
            g.AddEdge(5, 4, 6);
            g.AddEdge(2, 1, 7);
            g.AddEdge(3, 1, 9);
            g.AddEdge(6, 1, 14);
            g.AddEdge(3, 2, 10);
            g.AddEdge(4, 2, 15);
            g.AddEdge(6, 3, 2);
            g.AddEdge(4, 3, 11);
            g.AddEdge(5, 6, 9);
            g.AddEdge(4, 5, 6);

            g.AddVertex(7);
            g.AddVertex(8);
            g.AddEdge(7, 8, 1);
            g.AddEdge(8, 7, 1);

            var d = new Dijkstra<int>(g, g.V[1]);
            d.Calc();

            Assert.That(d.Distances.Count, Is.EqualTo(8));
            Assert.That(d.Distances.Select(p => p.Value),
                Is.EquivalentTo(new[] {0, 7, 9, 20, 20, 11, Double.PositiveInfinity, Double.PositiveInfinity}));
            Assert.That(d.Paths.ContainsKey(g.V[7]), Is.False);
            Assert.That(d.Paths.ContainsKey(g.V[8]), Is.False);
        }
    }
}
