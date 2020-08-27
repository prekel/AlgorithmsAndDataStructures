using System.IO;

namespace Alg_05.Core
{
    public class Splitter
    {
        public Splitter(BinaryReader input, BinaryWriter outputA, BinaryWriter outputB, int sectionLength)
        {
            Input = input;
            OutputA = outputA;
            OutputB = outputB;
            SectionLength = sectionLength;
        }

        private BinaryReader Input { get; }
        private BinaryWriter OutputA { get; }
        private BinaryWriter OutputB { get; }

        private int SectionLength { get; }

        public void Split()
        {
            Input.BaseStream.Seek(0, SeekOrigin.Begin);
            OutputA.BaseStream.Seek(0, SeekOrigin.Begin);
            OutputB.BaseStream.Seek(0, SeekOrigin.Begin);

            var i = 0;
            while (Input.BaseStream.Position / 4 != Input.BaseStream.Length / 4)
            {
                var a = Input.ReadInt32();
                if (i < SectionLength)
                {
                    OutputA.Write(a);
                }
                else
                {
                    OutputB.Write(a);
                }

                i++;
                i %= SectionLength * 2;
            }
        }
    }
}
