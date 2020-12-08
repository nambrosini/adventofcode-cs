using System;
using System.IO;
using System.Linq;

namespace day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Users\nicoa\source\repos\nambrosini\adventofcode-cs\2020\day05\input")
                .Select(l => CalculateId(l))
                .ToList();

            Console.WriteLine($"Part 1: {input.Max()}");

            var seat = Enumerable.Range(input.Min(), input.Max() - input.Min() + 1).Where(x => !input.Contains(x)).First();

            Console.WriteLine($"Part 2: {seat}");
        }

        static int CalculateId(string s)
        {
            var rows = s.Substring(0, 7);
            var minRow = 0;
            var maxRow = 127;

            foreach (char c in rows)
            {
                if (c == 'F')
                {
                    maxRow -= (maxRow - minRow + 1) / 2;
                } else
                {
                    minRow += (maxRow - minRow + 1) / 2;
                }
            }

            var row = rows[^1] == 'F' ? maxRow : minRow;

            var cols = s.Substring(s.Length - 3, 3);
            var minCol = 0;
            var maxCol = 7;

            foreach (char c in cols)
            {
                if (c == 'L')
                {
                    maxCol -= (maxCol - minCol + 1) / 2;
                } else
                {
                    minCol += (maxCol - minCol + 1) / 2;
                }
            }

            var col = cols[^1] == 'L' ? maxCol : minCol;

            return row * 8 + col;
        }
    }
}
