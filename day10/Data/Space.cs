using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.ComTypes;

namespace day10.Data
{
    class Space
    {
        public List<Point> Grid { get; set; }

        public Space(string[] rows)
        {
            Grid = new List<Point>();
            for (var i = 0; i < rows.Length; i++)
            {
                var chars = rows[i].ToCharArray();
                for (var j = 0; j < chars.Length; j++)
                {
                    Grid.Add(new Point(i, j, GetType(chars[j])));
                }
            }
        }

        public (Point, int) CountSeenAsteroids()
        {
            int max = 0;
            Point bestPoint = null;
            foreach (Point asteroid in Grid)
            {
                var count = MapAsteroid(asteroid);
                if (count > max)
                {
                    max = count;
                    bestPoint = asteroid;
                }

            }

            return (bestPoint, max);
        }

        public Point GetKillOrder(Point center)
        {
            var grid = Grid.Where(p => p.Type == Type.Asteroid && !p.Equals(center)).ToList();
            grid.ForEach(p => p.CalcAngleAndDistance(center));

            int killCount = 0;
            Point kill = null;

            while (grid.Count > 0 && killCount != 200)
            {
                HashSet<int> angles = grid.Select(e => e.Angle).ToHashSet();

                while (angles.Count > 0 && killCount != 200) {
                    var min = angles.Min();
                    kill = grid
                        .Where(p => p.Angle == min)
                        .Aggregate((x, y) => x.Distance < y.Distance ? x : y);
                    grid.Remove(kill);
                    angles.Remove(min);

                    killCount++;
                }
            }

            return kill;
        }

        private int MapAsteroid(Point asteroid)
        {
            return Grid.Where(p => p.Type == Type.Asteroid && p != asteroid)
                .Select(p => asteroid.CalcStep(p))
                .Distinct()
                .Count();
        }

        private Type GetType(char val)
        {
            return val switch
            {
                '#' => Type.Asteroid,
                '.' => Type.Empty,
                _ => throw new Exception("Type not recognized")
            };
        }
    }
}
