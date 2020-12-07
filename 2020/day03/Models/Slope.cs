using System;
namespace day03.Models
{
    public class Slope
    {
        public int Down { get; set; }
        public int Right { get; set; }

        public Slope(int x, int y)
        {
            Down = y;
            Right = x;
        }

        public int CountTrees(char[][] entries)
        {
            var rowCount = entries[0].Length;
            int x = 0;

            var count = 0;

            for (var y = 0; y < entries.Length; y += Down)
            {
                count += (entries[y][x] == '#') ? 1 : 0;
                x = (x + Right) % rowCount;
            }

            return count;
        }
    }
}
