using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day07
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Users\nicoa\source\repos\nambrosini\adventofcode-cs\2020\day07\input")
                .ToList();

            // Part 1
            Console.WriteLine($"Part 1: {Part1(input)}");

            // Part 2
            Console.WriteLine($"Part 2: {Part2(input)}");
        }

        public static int Part1(List<string> input)
        {
            Dictionary<String, Dictionary<String, int>> bags = new Dictionary<string, Dictionary<string, int>>();

            foreach (string s in input)
            {
                var s1 = s.Replace("bags", "").Replace("bag", "").Replace(".", "").Trim().Split("contain ");

                var bagColor = s1[0].Trim();

                s1 = s1[1].Split(",").Select(e => e.Trim()).ToArray();

                if (!bags.ContainsKey(bagColor))
                {
                    bags[bagColor] = new Dictionary<string, int>();
                }

                for (var i = 0; i < s1.Length; i++)
                {
                    var n = 0;
                    if (s1[i] == "no other")
                    {
                        continue;
                    }
                    else
                    {
                        n = int.Parse(s1[i][0..1]);
                    }
                    var key = s1[i].Substring(2);

                    if (!bags.ContainsKey(key))
                    {
                        bags[key] = new Dictionary<string, int>();
                    }

                    bags[key].Add(bagColor, n);
                }
            }

            List<string> bagsContainingGold = new List<string>(new string[] { "shiny gold" });

            for (var i = 0; i < bagsContainingGold.Count; i++)
            {
                if (bags[bagsContainingGold[i]].Count != 0)
                    Console.WriteLine(string.Join(", ", bags[bagsContainingGold[i]].Keys));
                bagsContainingGold.AddRange(bags[bagsContainingGold[i]].Keys);
            }

            bagsContainingGold.RemoveAt(0);

            return bagsContainingGold.Distinct().ToList().Count;
        }

        public static int Part2(List<string> input)
        {
            Dictionary<String, Dictionary<String, int>> bags = new Dictionary<string, Dictionary<string, int>>();

            foreach (string s in input)
            {
                var s1 = s.Replace("bags", "").Replace("bag", "").Replace(".", "").Trim().Split("contain ");

                var bagColor = s1[0].Trim();

                s1 = s1[1].Split(",").Select(e => e.Trim()).ToArray();

                if (!bags.ContainsKey(bagColor))
                {
                    bags[bagColor] = new Dictionary<string, int>();
                }

                for (var i = 0; i < s1.Length; i++)
                {
                    var n = 0;
                    if (s1[i] == "no other")
                    {
                        continue;
                    }
                    else
                    {
                        n = int.Parse(s1[i][0..1]);
                    }
                    var key = s1[i][2..];

                    if (!bags.ContainsKey(bagColor))
                    {
                        bags[bagColor] = new Dictionary<string, int>();
                    }

                    bags[bagColor].Add(key, n);
                }
            }

            return CalcRecursive("shiny gold", bags);
        }

        public static int CalcRecursive(string bagName, Dictionary<string, Dictionary<string, int>> bags)
        {
            if (bags[bagName].Count == 0)
            {
                return 0;
            }

            var res = 0;

            foreach (var bag in bags[bagName])
            {
                res += bag.Value * CalcRecursive(bag.Key, bags) + bag.Value; 
            }

            return res;
        }
    }
}
