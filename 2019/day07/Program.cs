using day07.IntCode;
using day07.IntCode.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day07
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = File.ReadAllText("input").Split(",").Select(e => int.Parse(e)).ToArray();

            #region Part 1
            List<List<int>> permutations = Permutator.Permute(new int[] { 0, 1, 2, 3, 4 });

            var max = permutations
                .Select(p => RunAmps1(p, input.ToArray()))
                .Aggregate((o1, o2) => o1 > o2 ? o1 : o2);

            Console.WriteLine($"Part 1: {max}");
            #endregion

            #region Part 2
            permutations = Permutator.Permute(new int[] { 5, 6, 7, 8, 9 });

            max = permutations
                .Select(p => RunAmps2(p, input.ToArray()))
                .Aggregate((o1, o2) => o1 > o2 ? o1 : o2);

            Console.WriteLine($"Part 2: {max}");
            #endregion
        }


        static int RunAmps1(List<int> input, int[] memory)
        {
            var output = 0;
            foreach (int v in input)
            {
                var icc = new IntCodeComputer(memory, v);
                output = (int)icc.Step(output);
            }

            return output;
        }

        static int RunAmps2(List<int> input, int[] memory)
        {
            IntCodeComputer[] iccs = new IntCodeComputer[5];
            for (var i = 0; i < iccs.Length; i++)
            {
                iccs[i] = new IntCodeComputer(memory, input[i]);
            }

            var output = 0;

            for (var i = 0; i < input.Count; i = (i + 1) % 5)
            {
                var o = iccs[i].Step(output);

                if (o != null)
                {
                    output = (int)o;
                }
                else
                {
                    break;
                }
            }

            return output;
        }

    }
}
