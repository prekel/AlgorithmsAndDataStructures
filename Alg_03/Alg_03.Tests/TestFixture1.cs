using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Alg_03.Core;
using NUnit.Framework;

namespace Alg_03.Tests
{
    [TestFixture(typeof(InclusionSort<int>), typeof(int))]
    [TestFixture(typeof(SelectionSort<int>), typeof(int))]
    [TestFixture(typeof(InclusionSort<double>), typeof(double))]
    [TestFixture(typeof(SelectionSort<double>), typeof(double))]
    [TestFixture(typeof(InclusionSort<string>), typeof(string))]
    [TestFixture(typeof(SelectionSort<string>), typeof(string))]
    [TestFixture(typeof(InclusionSort<DateTime>), typeof(DateTime))]
    [TestFixture(typeof(SelectionSort<DateTime>), typeof(DateTime))]
    [TestFixture(typeof(InclusionSort<Guid>), typeof(Guid))]
    [TestFixture(typeof(SelectionSort<Guid>), typeof(Guid))]
    public class TheorySampleTestsGeneric<TSort, T>
        where TSort : AbstractSort<T>, new()
        where T : IComparable
    {
        private TSort Sort { get; } = new TSort();

        [Datapoint]
        public List<double> ArrayDouble1 = new List<double>(new[] {1.2, 3.4, 1.2, 3.4});

        [Datapoint]
        public List<double> ArrayDouble2 = new List<double>(new[] {5.6, 7.8, 1.2, 3.4});

        [Datapoint]
        public List<int> ArrayInt = new List<int>(new[] {0, 1, 5, 3});

        [Datapoint]
        public List<int> ArrayInt1 = new List<int>(new[] {1, 3, 4, 34, 5, 6, 2, 33, 2});

        [Datapoint]
        public List<string> ArrayString1 =
            new List<string>(new[] {"gj", "hjhk", "ukft", "re", "aaa", "zzz", "hj", "fthf", "abcde"});

        [Datapoint]
        public List<string> ArrayString2 =
            new List<string>(new[] {"z", "x", "c"});

        [Datapoint]
        public List<DateTime> ArrayDateTime1 =
            new List<DateTime>(new[] {DateTime.Now, DateTime.Today, DateTime.MaxValue});

        [Datapoint]
        public List<DateTime> ArrayDateTime2 =
            new List<DateTime>(new[]
            {
                new DateTime(123, DateTimeKind.Utc), new DateTime(214324, DateTimeKind.Utc),
                new DateTime(325235235235, DateTimeKind.Utc), new DateTime(433344, DateTimeKind.Utc),
                new DateTime(0, DateTimeKind.Utc)
            });

        [Datapoint]
        public List<DateTime> ArrayDateTime3 =
            new List<DateTime>(new[]
            {
                DateTime.Now, new DateTime(2020, 05, 14), new DateTime(2025, 05, 14)
            });

        [Datapoint]
        public List<Guid> ListGuid1 = new List<Guid>(new[]
        {
            Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()
        });

        [Theory]
        public void TestGenericForArbitraryArray(List<T> array)
        {
            Assert.That(array.OrderBy(p => p).SequenceEqual(array), Is.False);
            Sort.Sort(array);
            Assert.That(array.OrderBy(p => p).SequenceEqual(array), Is.True);
        }
    }
}
