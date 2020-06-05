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

            while (InputA.BaseStream.Position != InputA.BaseStream.Length)
            {
                var readedA = 0;
                var readedB = 0;
                var mergedA = 0;
                var mergedB = 0;

                for (var i = 0; i < SectionLength * 2; i++)
                {
                    if (readedA == 0 && readedB == 0)
                    {
                        a = InputA.ReadInt32();
                        readedA++;
                        b = InputB.ReadInt32();
                        readedB++;
                    }
                    else if (mergedA == SectionLength)
                    {
                        if (readedB == mergedB)
                        {
                            b = InputB.ReadInt32();
                            readedB++;
                        }

                        Output.Write(b);
                        mergedB++;
                        continue;
                    }
                    else if (mergedB == SectionLength)
                    {
                        if (readedA == mergedA)
                        {
                            a = InputA.ReadInt32();
                            readedA++;
                        }

                        Output.Write(a);
                        mergedA++;
                        continue;
                    }
                    else
                    {
                        if (mergedA < mergedB)
                        {
                            b = InputB.ReadInt32();
                            readedB++;
                        }
                        else
                        {
                            a = InputA.ReadInt32();
                            readedA++;
                        }
                    }


                    if (a < b)
                    {
                        Output.Write(a);
                        mergedA++;
                    }
                    else
                    {
                        Output.Write(b);
                        mergedB++;
                    }
                }
            }
        }
    }
}
