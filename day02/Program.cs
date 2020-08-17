using day02.IntCode;
using System;
using System.IO;
using System.Linq;

namespace day02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = File.ReadAllText("input").Split(",").Select(e => int.Parse(e)).ToArray();

            // Part 1
            int[] memoryP1 = input.ToArray();

            var res1 = ExecuteFixedState(12, 2, memoryP1);

            Console.WriteLine($"Part 1: {res1}");

            // Part 2
            int[] memoryP2 = input.ToArray();

            var res2 = FindNounVerb(memoryP2);

            Console.WriteLine($"Part 2: {res2}");
        }

        static int ExecuteFixedState(int a, int b, int[] memory)
        {
            memory[1] = a;
            memory[2] = b;

            return new IntCodeComputer(memory).step();
        }

        static int FindNounVerb(int[] memory)
        {
            for (var noun = 0; noun < 100; noun++)
            {
                for (var verb = 0; verb < 100; verb++)
                {
                    var memoryCopy = memory.ToArray();

                    if (ExecuteFixedState(noun, verb, memoryCopy) == 19690720)
                    {
                        return 100 * noun + verb;
                    }
                }
            }

            throw new Exception("Noun and verb not found.");
        }
    }
}
