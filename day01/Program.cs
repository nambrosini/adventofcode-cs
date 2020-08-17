using System;
using System.IO;
using System.Linq;

namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input").Select(e => int.Parse(e));

            // Part 1
            var inputP1 = input.ToList();

            var res1 = inputP1.Select(e => CalcFuel(e)).Sum();

            Console.WriteLine($"Part1: {res1}");

            // Part 2
            var inputP2 = input.ToList();

            var res2 = inputP2.Select(e => CalcFuelRec(e)).Sum();

            Console.WriteLine($"Part2: {res2}");
        }

        static int CalcFuel(int fuel) => (int) Math.Floor(fuel / 3.0) - 2;

        static int CalcFuelRec(int fuel)
        {
            var f = CalcFuel(fuel);

            if (f <= 0)
            {
                return 0;
            }

            return f + CalcFuelRec(f);
        }
    } 
}
