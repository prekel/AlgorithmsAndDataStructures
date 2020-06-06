using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Alg_05.Core
{
    public class MergeSortFileHelper : IDisposable
    {
        public MergeSortFileHelper(string pathInput, string pathPrefixIntermediate, string suffixIntermediate,
            string pathOutput)
        {
            InputFile = new FileStream(pathInput, FileMode.Open);
            var input = new BinaryReader(InputFile);
            OutputFile = new FileStream(pathOutput, FileMode.Create);
            var output = new BinaryWriter(OutputFile);

            var count = input.BaseStream.Length / 4;

            Files = new List<FileStream>();
            var sectionLength = 1;
            while (sectionLength < count)
            {
                Files.Add(new FileStream($"{pathPrefixIntermediate}_{sectionLength}_SplittedA{suffixIntermediate}",
                    FileMode.Create));
                Files.Add(new FileStream($"{pathPrefixIntermediate}_{sectionLength}_SplittedB{suffixIntermediate}",
                    FileMode.Create));
                if (sectionLength * 2 < count)
                {
                    Files.Add(new FileStream($"{pathPrefixIntermediate}_{sectionLength * 2}_Merged{suffixIntermediate}",
                        FileMode.Create));
                }

                sectionLength *= 2;
            }

            var br = Files.Select(s => new BinaryReader(s));
            var bw = Files.Select(s => new BinaryWriter(s));

            Sort = new MergeSort(input, br, bw, output);
        }

        public FileStream InputFile { get; }

        public FileStream OutputFile { get; }

        public IList<FileStream> Files { get; }

        public MergeSort Sort { get; }

        public void Dispose()
        {
            InputFile.Dispose();
            OutputFile.Dispose();
            foreach (var i in Files)
            {
                i.Dispose();
            }
        }
    }
}
