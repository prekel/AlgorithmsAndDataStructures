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
            
            
        }
    }
}
