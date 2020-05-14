using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using Alg_03.Core;

namespace Alg_03.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static IEnumerable<AbstractSort<int>> IntSorts()
        {
            yield return new InclusionSort<int>();
            yield return new SelectionSort<int>();
        }

        [TestCaseSource(nameof(IntSorts))]
        public void Test1(AbstractSort<int> s)
        {
            var a = new List<int>(new[] {1, 3, 4, 34, 5, 6, 2, 33, 2});
            
            Assert.IsFalse(a.OrderBy(p => p).SequenceEqual(a));
            
            s.Sort(a);

            Assert.IsTrue(a.OrderBy(p => p).SequenceEqual(a));

            Assert.Pass();
        }
    }
}
