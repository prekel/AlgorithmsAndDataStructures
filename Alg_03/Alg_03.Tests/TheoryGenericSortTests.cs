using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using Alg_03.Core;


namespace Alg_03.Tests
{
    internal class Comparable : IComparable
    {
        private static readonly Random Random = new Random();
        private int Value { get; } = Random.Next();

        public int CompareTo(object? obj) => obj == null ? 1 : Value.CompareTo(((Comparable) obj).Value);
    }

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
    [TestFixture(typeof(InclusionSort<Comparable>), typeof(Comparable))]
    [TestFixture(typeof(SelectionSort<Comparable>), typeof(Comparable))]
    public class TheoryGenericSortTests<TSort, T>
        where TSort : AbstractSort<T>, new()
        where T : IComparable
    {
        private TSort Sort { get; } = new TSort();

        [Datapoint]
        private List<double> _arrayDouble1 = new List<double>(new[] {1.2, 3.4, 1.2, 3.4});

        [Datapoint]
        private List<double> _arrayDouble2 = new List<double>(new[] {5.6, 7.8, 1.2, 3.4});

        [Datapoint]
        private List<int> _arrayInt = new List<int>(new[] {0, 1, 5, 3});

        [Datapoint]
        private List<int> _arrayInt1 = new List<int>(new[] {1, 3, 4, 34, 5, 6, 2, 33, 2});

        [Datapoint]
        private List<string> _arrayString1 =
            new List<string>(new[] {"gj", "hjhk", "ukft", "re", "aaa", "zzz", "hj", "fthf", "abcde"});

        [Datapoint]
        private List<string> _arrayString2 =
            new List<string>(new[] {"z", "x", "c"});

        [Datapoint]
        private List<DateTime> _arrayDateTime1 =
            new List<DateTime>(new[] {DateTime.Now, DateTime.Today, DateTime.MaxValue});

        [Datapoint]
        private List<DateTime> _arrayDateTime2 =
            new List<DateTime>(new[]
            {
                new DateTime(123, DateTimeKind.Utc),
                new DateTime(214324, DateTimeKind.Utc),
                new DateTime(325235235235, DateTimeKind.Utc),
                new DateTime(433344, DateTimeKind.Utc),
                new DateTime(0, DateTimeKind.Utc)
            });

        [Datapoint]
        private List<DateTime> _arrayDateTime3 =
            new List<DateTime>(new[]
            {
                DateTime.Now,
                new DateTime(2020, 05, 14),
                new DateTime(2025, 05, 14)
            });

        [Datapoint]
        private List<Guid> _listGuid1 = new List<Guid>(new[]
        {
            Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()
        });

        [Datapoint]
        private List<Comparable> _listComparable1 =
            new List<Comparable>(Enumerable.Range(0, 100)
                .Select(p => new Comparable())
            );

        [Theory]
        public void TestGenericForArbitraryArray(List<T> list)
        {
            Assert.That(list.OrderBy(p => p).SequenceEqual(list), Is.False);
            Sort.Sort(list);
            Assert.That(list.OrderBy(p => p).SequenceEqual(list), Is.True);
        }
    }
}
