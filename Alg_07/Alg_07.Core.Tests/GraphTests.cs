using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace Alg_07.Core.Tests
{
    public class GraphTests
    {
        [Test]
        public void GraphTest1()
        {
            //  0 -1- 1 
            // 2|   /
            //  | /3
            //  2 -4- 3
            var g = new Graph<int>();
            Assert.That(g.E.Count, Is.EqualTo(0));
            Assert.That(g.V.Count, Is.EqualTo(0));
            var v0 = g.AddVertex(0);
            Assert.That(g.E.Count, Is.EqualTo(0));
            Assert.That(g.V.Count, Is.EqualTo(1));
            Assert.That(g.V.ContainsKey(0), Is.True);
            Assert.That(g.V.ContainsValue(v0), Is.True);
            Assert.That(g.V[0].Value, Is.EqualTo(0));
            var v1 = g.AddVertex(1);
            Assert.That(g.E.Count, Is.EqualTo(0));
            Assert.That(g.V.Count, Is.EqualTo(2));
            Assert.That(g.V.ContainsKey(1), Is.True);
            Assert.That(g.V.ContainsValue(v1), Is.True);
            Assert.That(g.V[1].Value, Is.EqualTo(1));
            var e01 = g.AddEdge(0, 1, 1);
            Assert.That(g.E.Count, Is.EqualTo(1));
            Assert.That(g.V.Count, Is.EqualTo(2));
            Assert.That(g.E.Contains(e01), Is.True);
            Assert.That(g.V[0].Contains(e01), Is.True);
            Assert.That(g.V[1].Contains(e01), Is.True);
            Assert.That(g.V[0].First(e => e == e01), Is.EqualTo(e01));
            Assert.That(g.V[1].First(e => e == e01), Is.EqualTo(e01));
            var v2 = g.AddVertex(2);
            Assert.That(g.E.Count, Is.EqualTo(1));
            Assert.That(g.V.Count, Is.EqualTo(3));
            Assert.That(g.V.ContainsKey(2), Is.True);
            Assert.That(g.V.ContainsValue(v2), Is.True);
            Assert.That(g.V[2].Value, Is.EqualTo(2));
            var e02 = g.AddEdge(0, 2, 2);
            Assert.That(g.E.Count, Is.EqualTo(2));
            Assert.That(g.V.Count, Is.EqualTo(3));
            Assert.That(g.E.Contains(e02), Is.True);
            Assert.That(g.V[0].Contains(e02), Is.True);
            Assert.That(g.V[2].Contains(e02), Is.True);
            Assert.That(g.V[0].First(e => e == e02), Is.EqualTo(e02));
            Assert.That(g.V[2].First(e => e == e02), Is.EqualTo(e02));
            var e12 = g.AddEdge(1, 2, 3);
            Assert.That(g.E.Count, Is.EqualTo(3));
            Assert.That(g.V.Count, Is.EqualTo(3));
            Assert.That(g.E.Contains(e12), Is.True);
            Assert.That(g.V[1].Contains(e12), Is.True);
            Assert.That(g.V[2].Contains(e12), Is.True);
            Assert.That(g.V[1].First(e => e == e12), Is.EqualTo(e12));
            Assert.That(g.V[2].First(e => e == e12), Is.EqualTo(e12));
            var v3 = g.AddVertex(3);
            Assert.That(g.E.Count, Is.EqualTo(3));
            Assert.That(g.V.Count, Is.EqualTo(4));
            Assert.That(g.V.ContainsKey(3), Is.True);
            Assert.That(g.V.ContainsValue(v3), Is.True);
            Assert.That(g.V[3].Value, Is.EqualTo(3));
            var e23 = g.AddEdge(2, 3, 4);
            Assert.That(g.E.Count, Is.EqualTo(4));
            Assert.That(g.V.Count, Is.EqualTo(4));
            Assert.That(g.E.Contains(e23), Is.True);
            Assert.That(g.V[2].Contains(e23), Is.True);
            Assert.That(g.V[3].Contains(e23), Is.True);
            Assert.That(g.V[2].First(e => e == e23), Is.EqualTo(e23));
            Assert.That(g.V[3].First(e => e == e23), Is.EqualTo(e23));

            
            
            g.RemoveEdge(0, 2);
            Assert.That(g.E.Count, Is.EqualTo(3));
            Assert.That(g.V.Count, Is.EqualTo(4));
            Assert.That(g.E.Contains(e02), Is.False);
            Assert.That(g.V[0].Contains(e02), Is.False);
            Assert.That(g.V[2].Contains(e02), Is.False);
            Assert.That(g.V[0].FirstOrDefault(e => e == e02), Is.Null);
            Assert.That(g.V[2].FirstOrDefault(e => e == e02), Is.Null);

            g.RemoveVertex(1);
            Assert.That(g.E.Count, Is.EqualTo(1));
            Assert.That(g.V.Count, Is.EqualTo(3));
            Assert.That(g.V.ContainsKey(1), Is.False);
            Assert.That(g.V.ContainsValue(v1), Is.False);
        }

        [Test]
        public void GraphTest2()
        {
            var g = new Graph<int>();
            var v = Enumerable.Range(0, 8).Select(i => g.AddVertex(i)).ToList();
            g.AddEdge(1, 2);
            g.AddEdge(0, 2);
            g.AddEdge(0, 3);
            g.AddEdge(4, 3);
            g.AddEdge(2, 4);
            g.AddEdge(2, 7);
            g.AddEdge(7, 4);
            g.AddEdge(6, 7);
            g.AddEdge(6, 4);
            g.AddEdge(5, 6);

            var dfs0 = new List<Vertex<int>>();
            g.Dfs(0, v1 => dfs0.Add(v1));
            Assert.That(dfs0.Select(v1 => v1.Value), Is.EquivalentTo(new[] {0, 2, 1, 4, 3, 6, 5, 7}));

            var bfs0 = new List<Vertex<int>>();
            g.Bfs(0, v1 => bfs0.Add(v1));
            Assert.That(bfs0.Select(v1 => v1.Value), Is.EquivalentTo(new[] {0, 2, 3, 1, 4, 7, 6, 5}));
        }

        [Test]
        public void GraphTest3()
        {
            var g = new Graph<string>();
            g.AddVertex("First");
            g.AddVertex("Second");
            g.AddVertex("Third");
            g.AddVertex("Fourth");

            g.AddEdge("First", "Second");
            g.AddEdge("First", "Fourth");

            var dfs0 = new List<Vertex<string>>();
            g.Dfs("First", v1 => dfs0.Add(v1));
            Assert.That(dfs0.Select(v1 => v1.Value), Is.EquivalentTo(new[] {"First", "Fourth", "Second"}));

            var bfs0 = new List<Vertex<string>>();
            g.Bfs("First", v1 => bfs0.Add(v1));
            Assert.That(bfs0.Select(v1 => v1.Value), Is.EquivalentTo(new[] {"First", "Fourth", "Second"}));
        }
    }
}
