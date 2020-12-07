using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace day10.Data
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Type Type { get; set; }
        public int Angle { get; set; }
        public int Distance { get; set; }

        public Point(int x, int y, Type type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public (int, int) CalcStep(Point other)
        {
            var (diffX, diffY) = (other.X - this.X, other.Y - this.Y);
            var mcd = MCD(diffX, diffY);
            return (diffX / mcd, diffY / mcd);
        }

        private int MCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a > b)
            {
                (a, b) = (b, a);
            }

            while (b != 0)
            {
                var tmp = b;
                b = a % b;
                a = tmp;
            }

            return a;
        }

        public void CalcAngleAndDistance(Point from)
        {
            var distX = this.X - from.X;
            var distY = this.Y - from.Y;

            var angle = Math.Atan2((double)distY, (double)distX) + Math.PI / 2.0;
            angle = (angle < 0) ? angle + 2.0 * Math.PI : angle;

            this.Angle = (int) (angle * 1_000_000);
            this.Distance = (int) (Math.Sqrt(Math.Pow(distX, 2) + Math.Pow(distY, 2)) * 1_000_000);
        }

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                var point = (Point)obj;

                return this.X == point.X && this.Y == point.Y && this.Type == point.Type && this.GetHashCode() == obj.GetHashCode();
            }

            throw new Exception("Point can only be compared to point.");
        }

        public override int GetHashCode()
        {
            return this.X * 13 + this.Y * 17 + (int) this.Type * 23;
        }
    }
}
