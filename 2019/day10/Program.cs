using day10.Data;
using System;
using System.IO;
using System.Linq;

namespace day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"/Users/nambrosini/Projects/adventofcode-cs/day10/input").ToArray();

            var space = new Space(input);

            #region Part 1
            var (bestPoint, count) = space.CountSeenAsteroids();
            Console.WriteLine($"Part 1: {count}");
            #endregion

            #region Part 2
            var kill200 = space.GetKillOrder(bestPoint);
            Console.WriteLine($"Part 2: { kill200.X * 100 + kill200.Y }");
            #endregion
        }
    }
}
