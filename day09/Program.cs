using day09.IntCode;
using System;
using System.IO;
using System.Linq;

namespace day09
{
    class Program
    {
        static void Main()
        {
            long[] input = File.ReadAllText(@"C:\Users\Nico Ambrosini\source\repos\adventofcode-cs\day09\input").Split(',').Select(s => long.Parse(s)).ToArray();

            #region Part 1
            Console.WriteLine($"Part 1: {new IntCodeComputer(input.ToArray(), null).Step(1)}");
            #endregion
            #region Part 2
            Console.WriteLine($"Part 1: {new IntCodeComputer(input.ToArray(), null).Step(2)}");
            #endregion
        }
    }
}
