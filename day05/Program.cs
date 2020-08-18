using day05.IntCode;
using System;
using System.IO;
using System.Linq;

namespace day05
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = File.ReadAllText("input").Split(",").Select(e => int.Parse(e)).ToArray();

            // Part 1
            int[] memoryP1 = input.ToArray();

            int code = 0;
            var icc = new IntCodeComputer(memoryP1);

            while (code == 0)
            {
                code = icc.step(1);
            }

            Console.WriteLine($"Part 1: {code}");

            // Part 2
            int[] memoryP2 = input.ToArray();

            Console.WriteLine($"Part 2: {new IntCodeComputer(memoryP2).step(5)}");
        }
    }
}
