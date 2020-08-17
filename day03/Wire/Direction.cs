using System;
using System.Collections.Generic;
using System.Text;

namespace day03.Wire
{
    public enum DirectionEnum
    {
        Up,
        Right,
        Down,
        Left
    }

    public class Direction
    {
        public DirectionEnum Dir { get; set; }
        public int Value { get; set; }
    }

    public static class StringExtension
    {
        public static Direction ToDirection(this string value)
        {
            DirectionEnum dir;

            switch (value.Substring(0, 1))
            {
                case "U":
                    dir = DirectionEnum.Up;
                    break;
                case "R":
                    dir = DirectionEnum.Right;
                    break;
                case "D":
                    dir = DirectionEnum.Down;
                    break;
                case "L":
                    dir = DirectionEnum.Left;
                    break;
                default:
                    throw new ArgumentException("Direction not recognized.");
            }

            var distance = int.Parse(value.Substring(1));

            return new Direction
            {
                Dir = dir,
                Value = distance
            };
        }
    }
}
