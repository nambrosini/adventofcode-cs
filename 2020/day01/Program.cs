using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var entries = File.ReadAllLines(@"/Users/nambrosini/Projects/adventofcode-cs/2020/day01/input")
                .Select(l => int.Parse(l))
                .ToList();

            // Part 1
            Console.WriteLine($"Part1: {Part1(entries)}");

            // Part 2
            Console.WriteLine($"Part2: {Part2(entries)}");
        }

        static int Part1(List<int> entries)
        {
            foreach (var e in entries)
            {
                if (entries.Contains(2020 - e))
                {
                    return e * (2020 - e);
                }
            }

            throw new Exception("Searched combination not found");
        }

        static int Part2(List<int> entries)
        {
            foreach (var a in entries)
            {
                foreach (var b in entries)
                {
                    if (entries.Contains(2020 - a - b))
                    {
                        return a * b * (2020 - a - b);
                    }
                }
            }

            throw new Exception("Searched combination not found");
        }
    }
}
