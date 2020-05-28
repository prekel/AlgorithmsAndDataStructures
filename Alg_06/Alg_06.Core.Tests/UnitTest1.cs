using System.Collections.Generic;

using NUnit.Framework;

namespace Alg_06.Core.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var g = new Graph<int>();
            g.AddVertex(0);
            g.AddVertex(1);
            g.AddEdge(0, 1);
            g.AddVertex(2);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddVertex(3);
            g.AddEdge(2, 3);
            var bfsres = new List<Vertex<int>>();
            g.Dfs(g.V[3], v => bfsres.Add(v));
        }
    }
}
