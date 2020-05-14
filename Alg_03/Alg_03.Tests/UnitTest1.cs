using System;
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
            var a = new List<IComparable>(new IComparable[] {1, 3, 4, 34, 5, 6, 2, 33, 2});

            var s = new InclusionSort(a);
             s.Sort();
            
            Assert.Pass();
        }
    }
}
