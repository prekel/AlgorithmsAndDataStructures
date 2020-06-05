using System;
using System.IO;

namespace Alg_05.Core
{
    public class Merger
    {
        public Merger(BinaryReader inputA, BinaryReader inputB, BinaryWriter output, int sectionLength)
        {
            InputA = inputA;
            InputB = inputB;
            Output = output;
            SectionLength = sectionLength;
        }

        private BinaryReader InputA { get; }
        private BinaryReader InputB { get; }
        private BinaryWriter Output { get; }
        private int SectionLength { get; }

        public void Merge()
        {
            var a = 0;
            var b = 0;

            while (true)
            {
                var readA = 0;
                var readB = 0;
                var read = 0;
                for (var i = 0; i < SectionLength * 2; i++)
                {
                    if (readA == SectionLength)
                    {
                        b = InputB.ReadInt32();
                        readB++;
                    }
                    else if (readB == SectionLength)
                    {
                        a = InputA.ReadInt32();
                        readA++;
                    }
                    else if (read == 0 || read == 1)
                    {
                        a = InputA.ReadInt32();
                        readA++;
                    }
                    else if (read == 0 || read == 2)
                    {
                        b = InputB.ReadInt32();
                        readB++;
                    }

                    if (a < b)
                    {
                        read = 1;
                    }
                    else
                    {
                        read = 2;
                    }

                    Output.Write(Math.Min(a, b));
                }
            }
        }
    }
}
