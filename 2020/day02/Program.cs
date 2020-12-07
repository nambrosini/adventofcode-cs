using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using day02.Models;

namespace day02
{
    class Program
    {
        static void Main(string[] args)
        {
            var entries = File.ReadAllLines(@"/Users/nambrosini/Projects/adventofcode-cs/2020/day02/input")
                .Select(l => (Policy) l)
                .ToList();

            // Part 1
            Console.WriteLine($"Part 1: {Part1(entries)}");

            // Part 2
            Console.WriteLine($"Part 2: {Part2(entries)}");
        }

        static int Part1(List<Policy> entries)
        {
            return entries
                .Select(l => l.CheckPart1Policy())
                .Count(x => x);
        }

        static int Part2(List<Policy> entries)
        {
            return entries
                .Select(l => l.CheckPart2Policy())
                .Count(x => x);
        }
    }
}
