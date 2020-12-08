using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using day04.Models;

namespace day04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Passport> entries = File.ReadAllText(@"C:\Users\nicoa\Source\Repos\nambrosini\adventofcode-cs\2020\day04\input")
                .Split("\r\n\r\n")
                .Select(l => l.Replace("\n", " "))
                .Select(l => (Passport)l)
                .Where(p => p != null)
                .ToList();

            Console.WriteLine($"Part 1: {entries.Count}");

            Console.WriteLine($"Part 2: {entries.Where(p => p.ValidatePart2()).ToList().Count}");
        }
    }
}
