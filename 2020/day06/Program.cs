using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace day06
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText(@"C:\Users\nicoa\source\repos\nambrosini\adventofcode-cs\2020\day06\input")
                .Split("\r\n\r\n")
                .ToList();

            int part1 = input
                .Select(p => p.Replace("\n", "").Replace("\r", ""))
                .Select(p => p.ToCharArray().Distinct().ToArray())
                .Select(x => x.Length)
                .Aggregate((x, y) => x + y);

            Console.WriteLine($"Part 1: {part1}");

            // Part 2
            var part2 = input
                .Select(p => p.Replace("\r", ""))
                .Select(p => p.Split("\n").Select(s => s.ToCharArray()).ToArray())
                .ToList();

            List<string> ok = new List<string>();

            foreach (var group in part2)
            {
                var s = new StringBuilder();
                var firstPassenger = group[0];
                foreach (var letter in firstPassenger)
                {
                    var letterAll = true;
                    for (var i = 1; i < group.Length; i++)
                    {
                        if (!group[i].Contains(letter))
                        {
                            letterAll = false;
                            break;
                        }
                    }
                    if (letterAll)
                    {
                        s.Append(letter);
                    }
                }
                ok.Add(s.ToString());
            }

            Console.WriteLine($"Part 2: {ok.Select(l => l.Length).Sum()}");
        }
    }
}
