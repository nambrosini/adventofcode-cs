using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using day03.Models;

namespace day03
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] entries = File.ReadAllLines(@"/Users/nambrosini/Projects/adventofcode-cs/2020/day03/input")
                .Select(x => x.ToCharArray().ToArray())
                .ToArray();

            // Part 1

            Console.WriteLine($"Part 1: {Part1(entries)}");

            // Part 2

            Console.WriteLine($"Part 2: {Part2(entries)}");
        }

        static int Part1(char[][] entries)
        {
            return new Slope(3, 1).CountTrees(entries);
        }

        static long Part2(char[][] entries)
        {
            Slope[] slopes =
            {
                new Slope(1, 1),
                new Slope(3, 1),
                new Slope(5, 1),
                new Slope(7, 1),
                new Slope(1, 2)
            };

            slopes.Select(x => x.CountTrees(entries)).ToList().ForEach(x => Console.WriteLine(x));

            return slopes
                .Select(x => (long)(x.CountTrees(entries)))
                .Aggregate((x, y) => x * y);
        }
    }
}
