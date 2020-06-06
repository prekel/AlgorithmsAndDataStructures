using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Alg_05.Core
{
    public class MergeSort
    {
        public MergeSort(BinaryReader input, IEnumerable<BinaryReader> intermediateInputs,
            IEnumerable<BinaryWriter> intermediateOutputs, BinaryWriter output)
        {
            Input = input;
            IntermediateInputs = intermediateInputs.Append(input).ToList();
            IntermediateOutputs = intermediateOutputs.Append(output).ToList();
            Output = output;
        }

        private BinaryReader Input { get; }
        private IList<BinaryReader> IntermediateInputs { get; }
        private IList<BinaryWriter> IntermediateOutputs { get; }
        private BinaryWriter Output { get; }

        public void Sort()
        {
            var sectionLength = 1;
            var count = Input.BaseStream.Length / 4;
            var i = 0;
            var prevMerged = Input;
            while (sectionLength < count)
            {
                var splitter = new Splitter(prevMerged, IntermediateOutputs[i], IntermediateOutputs[i + 1],
                    sectionLength);
                splitter.Split();

                var merger = new Merger(IntermediateInputs[i], IntermediateInputs[i + 1], IntermediateOutputs[i + 2],
                    sectionLength);
                merger.Merge();

                prevMerged = IntermediateInputs[i + 2];
                i += 3;
                sectionLength *= 2;
            }
        }
    }
}
