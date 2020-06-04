using System;
using System.IO;

namespace Alg_05.Core
{
    public class Merger
    {
        private BinaryReader InputA { get; }
        private BinaryReader InputB { get; }
        private BinaryWriter Output { get; }
        private int SectionLength { get; }

        public Merger(BinaryReader inputA, BinaryReader inputB, BinaryWriter output, int sectionLength)
        {
            InputA = inputA;
            InputB = inputB;
            Output = output;
            SectionLength = sectionLength;
        }

        public void Merge()
        {
            var b = 0;
            var c = 0;

            while (true)
            {
                var read = 0;
                for (var i = 0; i < SectionLength * 2; i++)
                {
                    if (read == 0 || read == 1)
                    {
                        b = InputA.ReadInt32();
                    }

                    if (read == 0 || read == 2)
                    {
                        c = InputB.ReadInt32();
                    }

                    if (b < c)
                    {
                        read = 1;
                    }
                    else
                    {
                        read = 2;
                    }
                    
                    Output.Write(Math.Min(b, c));
                }
            }
        }
    }
}
