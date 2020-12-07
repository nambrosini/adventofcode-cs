using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace day03.Wire
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public int Distance(Point other)
        {
            return Math.Abs(other.X - this.X) + Math.Abs(other.Y - this.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                var other = (Point)obj;
                return this.X == other.X && this.Y == other.Y;
            }

            throw new Exception("obj is not a Point.");
        }

        public override int GetHashCode()
        {
            return X * 13 + Y * 21;
        }
    }

    public class PointComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point a, Point b)
        {
            return a.Equals(b);
        }

        public int GetHashCode([DisallowNull] Point obj)
        {
            return obj.GetHashCode();
        }
    }
}
