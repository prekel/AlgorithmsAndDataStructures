using System;
using System.IO;
using System.Runtime.Serialization;

namespace Alg_05.Core
{
    public class Splitter
    {
        private BinaryReader Input { get; }
        private BinaryWriter OutputA { get; }
        private BinaryWriter OutputB { get; }

        private int SectionLength { get; }

        public Splitter(BinaryReader input, BinaryWriter outputA, BinaryWriter outputB, int sectionLength)
        {
            Input = input;
            OutputA = outputA;
            OutputB = outputB;
            SectionLength = sectionLength;
        }

        public void Split()
        {
            var i = 0;
            while (Input.BaseStream.Position != Input.BaseStream.Length)
            {
                var a = Input.ReadInt32();
                if (i++ % (SectionLength * 2) == 0)
                {
                    OutputA.Write(a);
                }
                else
                {
                    OutputB.Write(a);
                }
            }
        }
    }
}
