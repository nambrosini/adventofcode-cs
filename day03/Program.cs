using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using day03.Wire;

namespace day03
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input");

            var wire1 = Wire.Wire.CreateWire(input[0].Split(',').Select(e => e.ToDirection()).ToArray());
            var wire2 = Wire.Wire.CreateWire(input[1].Split(',').Select(e => e.ToDirection()).ToArray());

            // Part 1
            List<Point> commonPoints = wire1.Path.Intersect(wire2.Path, new PointComparer()).ToList();
            commonPoints.Remove(new Point(0, 0));

            var res1 = commonPoints.Select(e => e.Distance(new Point(0, 0))).Min();

            Console.WriteLine($"Part 1: {res1}");

            // Part 2
            var res2 = commonPoints.Select(e => wire1.Path.IndexOf(e) + wire2.Path.IndexOf(e)).Min();

            Console.WriteLine($"Part 2: {res2}");
        }
    }
}
