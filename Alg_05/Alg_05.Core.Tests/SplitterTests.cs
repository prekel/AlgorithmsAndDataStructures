using System.IO;

using NUnit.Framework;

namespace Alg_05.Core.Tests
{
    public class SplitterTests
    {
        [Test]
        public void Test1()
        {
            var a = new[] {54, 32, 12, 30, 16, 24, 92, 19};

            var b = new byte[a.Length * 4];
            using (var g = new BinaryWriter(new MemoryStream(b)))
            {
                foreach (var i in a)
                {
                    g.Write(i);
                }
            }

            var o1 = new byte[a.Length * 4 / 2];
            var o2 = new byte[a.Length * 4 / 2];

            var s = new Splitter(new BinaryReader(new MemoryStream(b)), new BinaryWriter(new MemoryStream(o1)),
                new BinaryWriter(new MemoryStream(o2)), 1);
            s.Split();

            var r = new byte[a.Length * 4];
            var m = new Merger(new BinaryReader(new MemoryStream(o1)), new BinaryReader(new MemoryStream(o2)),
                new BinaryWriter(new MemoryStream(r)), 1);
            m.Merge();


            var t1 = new byte[a.Length * 4 / 2];
            var t2 = new byte[a.Length * 4 / 2];
            var s2 = new Splitter(new BinaryReader(new MemoryStream(r)), new BinaryWriter(new MemoryStream(t1)),
                new BinaryWriter(new MemoryStream(t2)), 2);
            s2.Split();


            var r1 = new byte[a.Length * 4];
            var m2 = new Merger(new BinaryReader(new MemoryStream(t1)), new BinaryReader(new MemoryStream(t2)),
                new BinaryWriter(new MemoryStream(r1)), 2);
            m2.Merge();


            var q1 = new byte[a.Length * 4 / 2];
            var q2 = new byte[a.Length * 4 / 2];
            var w2 = new Splitter(new BinaryReader(new MemoryStream(r1)), new BinaryWriter(new MemoryStream(q1)),
                new BinaryWriter(new MemoryStream(q2)), 4);
            w2.Split();


            var r4 = new byte[a.Length * 4];
            var m4 = new Merger(new BinaryReader(new MemoryStream(q1)), new BinaryReader(new MemoryStream(q2)),
                new BinaryWriter(new MemoryStream(r4)), 4);
            m4.Merge();
        }
    }
}
