using day11.IntCode;
using day11.Data;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day11
{
    class Program
    {
        static void Main()
        {
            long[] input = File.ReadAllText(@"/Users/nambrosini/Projects/adventofcode-cs/day11/input")
                .Split(',')
                .Select(s => long.Parse(s))
                .ToArray();

            #region Part 1
            HashSet<(int, int)> panels = new HashSet<(int, int)>();
            var icc = new IntCodeComputer(input.ToArray(), null);
            Robot robot = new Robot();
            long res = icc.Step(robot.Position.Color);
            bool color = true;

            do {
                if (color) {
                    robot.Position.Color = (int) res;
                } else {
                    if (res == 0) {
                        robot.Dir.TurnLeft();
                    } else {
                        robot.Dir.TurnRight();
                    }
                    panels.Add(
                            (robot.Position.Coordinates.X,
                            robot.Position.Coordinates.Y)
                    );
                    robot.Move();
                }

                color = !color;
                res = icc.Step(robot.Position.Color);
            } while (res == 0 || res == 1);

            Console.WriteLine($"Part 1: {panels.Count()}");
            #endregion
            #region Part 2
            #endregion
        }
    }
}
