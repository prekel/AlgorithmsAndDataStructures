using System.Collections.Generic;
using System.IO;
using System.Linq;

using NUnit.Framework;

namespace Alg_05.Core.Tests
{
    public class MergeSortFileHelperTests
    {
        [Test]
        public void FileMergeSortTest1()
        {
            var a = new[] {54, 32, 12, 30, 16, 24, 92};
            var pi = "test1.bin";
            var pip = "test1_intr";
            var pis = ".bin";
            var po = "test1_result.bin";

            using (var g = new BinaryWriter(new FileStream(pi, FileMode.Create)))
            {
                foreach (var i in a)
                {
                    g.Write(i);
                }
            }

            using (var msh = new MergeSortFileHelper(pi, pip, pis, po))
            {
                var sort = msh.Sort;
                sort.Sort();
            }

            var b = new List<int>();
            using (var g = new BinaryReader(new FileStream(po, FileMode.Open)))
            {
                b.AddRange(Enumerable.Range(0, a.Length).Select(i => g.ReadInt32()));
            }

            Assert.That(b, Is.EquivalentTo(new[] {12, 16, 24, 30, 32, 54, 92}));
        }
    }
}
