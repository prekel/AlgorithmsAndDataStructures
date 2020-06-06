using System.Collections.Generic;
using System.IO;
using System.Linq;

using NUnit.Framework;

namespace Alg_05.Core.Tests
{
    public class MergeSortTests
    {
        [Test]
        public void MergeSortTest1()
        {
            var a = new[] {54, 32, 12, 30, 16, 24, 92};

            var r1 = new byte[a.Length * 4];
            using (var g = new BinaryWriter(new MemoryStream(r1)))
            {
                foreach (var i in a)
                {
                    g.Write(i);
                }
            }

            var oa1 = new byte[16];
            var ob1 = new byte[12];
            var r2 = new byte[28];
            var oa2 = new byte[16];
            var ob2 = new byte[12];
            var r4 = new byte[28];
            var oa4 = new byte[16];
            var ob4 = new byte[12];
            var r8 = new byte[28];

            var interm = new[] {oa1, ob1, r2, oa2, ob2, r4, oa4, ob4};

            var br = interm.Select(s => new BinaryReader(new MemoryStream(s)));
            var bw = interm.Select(s => new BinaryWriter(new MemoryStream(s)));

            var sort = new MergeSort(new BinaryReader(new MemoryStream(r1)), br, bw,
                new BinaryWriter(new MemoryStream(r8)));

            sort.Sort();

            var b = new List<int>();
            using (var g = new BinaryReader(new MemoryStream(r8)))
            {
                b.AddRange(Enumerable.Range(0, 7).Select(i => g.ReadInt32()));
            }

            Assert.That(b, Is.EquivalentTo(a.OrderBy(y => y)));
        }
    }
}
