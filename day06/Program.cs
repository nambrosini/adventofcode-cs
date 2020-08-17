using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace day06
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Orbit> input = File.ReadAllLines(@"C:\Users\Nico Ambrosini\source\repos\adventofcode-cs\day06\input").Select(l => (Orbit)l).ToList();

            #region Part 1
            Dictionary<string, List<Orbit>> orbitMap = new Dictionary<string, List<Orbit>>();


            foreach (Orbit orbit in input)
            {
                string key = orbit.U;
                orbitMap.TryAdd(orbit.V, new List<Orbit>());
                if (orbitMap.Keys.Contains(key))
                {
                    orbitMap[key].Add(orbit);
                }
                else
                {
                    orbitMap.Add(key, new List<Orbit>(new Orbit[] { orbit }));
                }
            }

            Dictionary<string, int> dists = new Dictionary<string, int>();
            var com = orbitMap["COM"];
            CalcDistFrom("COM", orbitMap, dists, 0);

            Console.WriteLine($"Part 1: {dists.Values.Sum()}");
            #endregion

            #region Part 2
            Dictionary<string, HashSet<string>> reachables = new Dictionary<string, HashSet<string>>();
            CalcReachablesFrom("COM", orbitMap, reachables);

            var sanyou = reachables.Where(o => o.Value.Contains("SAN") && o.Value.Contains("YOU")).Aggregate((x, y) => dists[x.Key] > dists[y.Key] ? x : y);
            int dist_sanyou = dists[sanyou.Key];
            int dist_san = dists["SAN"];
            int dist_you = dists["YOU"];

            Console.WriteLine($"Part 2: {(dist_san - dist_sanyou) + (dist_you - dist_sanyou) - 2}");

            #endregion
        }

        private static void CalcDistFrom(string pos, Dictionary<string, List<Orbit>> orbitMap, Dictionary<string, int> dists, int dist)
        {
            dists.Add(pos, dist);
            foreach (Orbit e in orbitMap[pos])
            {
                CalcDistFrom(e.V, orbitMap, dists, dist + 1);
            }
        }

        private static void CalcReachablesFrom(string pos, Dictionary<string, List<Orbit>> orbitMap, Dictionary<string, HashSet<string>> reachables)
        {
            reachables[pos] = new HashSet<string>();

            foreach (Orbit o in orbitMap[pos])
            {
                reachables[pos].Add(o.V);
                CalcReachablesFrom(o.V, orbitMap, reachables);
                var child = reachables[o.V];
                foreach (string c in child)
                {
                    reachables[pos].Add(c);
                }
            }
        }
    }

    class Orbit
    {
        public string U { get; set; }
        public string V { get; set; }

        public Orbit(string u, string v)
        {
            U = u;
            V = v;
        }

        public static implicit operator Orbit(string val)
        {
            var split = val.Split(')');
            return new Orbit(split[0], split[1]);
        }
    }
}
