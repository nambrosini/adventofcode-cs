namespace day11.Data
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

        public static Point operator +(Point point, DirectionEnum direction) {

            var (x, y) = direction switch
            {
                DirectionEnum.Up => (0, 1),
                DirectionEnum.Down => (0, -1),
                DirectionEnum.Right => (1, 0),
                DirectionEnum.Left => (-1, 0),
                _ => throw new System.NotImplementedException()
            };
            return new Point(point.X + x, point.Y + y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Point other)
            {
                return this.X == other.X && this.Y == other.Y;
            }

            throw new System.Exception("obj must be of type Point.");
        }

        public override int GetHashCode()
        {
            return 13 * this.X + 17 * this.Y;
        }
    }
}