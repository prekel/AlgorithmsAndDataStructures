using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace Alg_06.Core.Tests
{
    public class GraphTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GraphTest1()
        {
            //  0 - 1 
            //  | /
            //  2 - 3
            var g = new Graph<int>();
            g.AddVertex(0);
            g.AddVertex(1);
            g.AddEdge(0, 1);
            g.AddVertex(2);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddVertex(3);
            g.AddEdge(2, 3);
            var dfs = new List<Vertex<int>>();
            g.Dfs(g.V[3], v => dfs.Add(v));

            Assert.That(dfs.Count, Is.EqualTo(4));
            Assert.That(dfs.Select(v => v.Value), Is.EquivalentTo(new[] {3, 2, 0, 1}));
        }
    }
}
