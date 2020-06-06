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
            InputA.BaseStream.Seek(0, SeekOrigin.Begin);
            InputB.BaseStream.Seek(0, SeekOrigin.Begin);
            Output.BaseStream.Seek(0, SeekOrigin.Begin);

            var a = 0;
            var b = 0;

            var mergedAllA = 0;
            var mergedAllB = 0;
            var countA = InputA.BaseStream.Length / 4;
            var countB = InputB.BaseStream.Length / 4;

            var j = 0;
            var readedA = 0;
            var readedB = 0;
            var mergedA = 0;
            var mergedB = 0;
            while (mergedAllA != countA ||
                   mergedAllB != countB)
            {
                if (j == 0)
                {
                    readedA = 0;
                    readedB = 0;
                    mergedA = 0;
                    mergedB = 0;
                }

                j++;
                j %= SectionLength * 2;

                if (mergedA == SectionLength || mergedAllA == countA)
                {
                    if (readedB == mergedB)
                    {
                        b = InputB.ReadInt32();
                        readedB++;
                    }

                    Output.Write(b);
                    mergedB++;
                    mergedAllB++;
                    continue;
                }

                if (mergedB == SectionLength || mergedAllB == countB)
                {
                    if (readedA == mergedA)
                    {
                        a = InputA.ReadInt32();
                        readedA++;
                    }

                    Output.Write(a);
                    mergedA++;
                    mergedAllA++;
                    continue;
                }

                if (readedA == 0 && readedB == 0)
                {
                    a = InputA.ReadInt32();
                    readedA++;
                    b = InputB.ReadInt32();
                    readedB++;
                }
                else
                {
                    if (mergedA == mergedB && readedA > readedB || readedB == mergedB)
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
                    mergedAllA++;
                }
                else
                {
                    Output.Write(b);
                    mergedB++;
                    mergedAllB++;
                }
            }
        }
    }
}
