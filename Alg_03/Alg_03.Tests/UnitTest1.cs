using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
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

        [Test]
        public void Test1()
        {
            var a = new List<int>(new[] {1, 3, 4, 34, 5, 6, 2, 33, 2});

            Assert.IsFalse(a.OrderBy(p => p).SequenceEqual(a));
            
            var s = new InclusionSort<int>(a);
            s.Sort();

            Assert.IsTrue(a.OrderBy(p => p).SequenceEqual(a));

            Assert.Pass();
        }
    }
}
