using System;
using System.Collections.Generic;
using System.Linq;
using Alg_03.Core;
using NUnit.Framework;

namespace Alg_03.Tests
{
    [TestFixture(typeof(InclusionSort<int>), typeof(int)), NUnit.Framework.]
    [TestFixture(typeof(SelectionSort<int>), typeof(int))]
    [TestFixtureSource("FixtureArgs")]
    public class TestFixture1<TSort, T>
        where TSort : AbstractSort<T>, new()
        where T : IComparable
    {
        private TSort Sort { get; } = new TSort();
        private IList<T> Array { get; }

        public TestFixture1(IList<T> array) => Array = array;

        private static object[] FixtureArgs =
        {
            new List<int>(new[] {1, 3, 4, 34, 5, 6, 2, 33, 2}),
            new List<int>(new[] {989, 2, 4, 34, 5, 6, 2, 33, 2})
        };
        
        [Test]
        public void Test1()
        { 
            Assert.IsFalse(Array.OrderBy(p => p).SequenceEqual(Array));

            Sort.Sort(Array);

            Assert.IsTrue(Array.OrderBy(p => p).SequenceEqual(Array));

            Assert.Pass();
        }
    }
}
