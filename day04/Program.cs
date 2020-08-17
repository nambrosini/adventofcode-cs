using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = File.ReadAllText(@"C:\Users\Nico Ambrosini\source\repos\adventofcode-cs\day04\input").Split('-').Select(e => int.Parse(e)).ToArray();

            // Part 1

            Console.WriteLine($"Part 1: {CountPossiblePasswordsPart1(input[0], input[1])}");

            // Part 2

            Console.WriteLine($"Part 2: {CountPossiblePasswordsPart2(input[0], input[1])}");
        }

        static int CountPossiblePasswordsPart1(int start, int end)
        {
            var res = 0;
            for (var i = start; i <= end; i++)
            {
                res += Convert.ToInt32(CheckPasswordPart1(i));
            }

            return res;
        }

        static bool CheckPasswordPart1(int password)
        {
            int last = 10;
            bool hasDouble = false;

            while (password > 0)
            {
                if (password % 10 <= last)
                {
                    if (password % 10 == last)
                    {
                        hasDouble = true;
                    }
                } 
                else
                {
                    return false;
                }

                last = password % 10;
                password /= 10;

            }

            return hasDouble;
        }

        static int CountPossiblePasswordsPart2(int start, int end)
        {
            var res = 0;
            for (var i = start; i <= end; i++)
            {
                res += Convert.ToInt32(CheckPasswordPart2(i));
            }

            return res;
        }

        static bool CheckPasswordPart2(int password)
        {
            var last = 10;
            ConcurrentDictionary<int, int> nums = new ConcurrentDictionary<int, int>();

            while (password > 0)
            {
                var val = password % 10;

                if (val > last)
                {
                    return false;
                }

                nums.AddOrUpdate(val, 1, (id, count) => count += 1);
                last = val;
                password /= 10;
            }


            return nums.Any(v => v.Value == 2);
        }
    }
}
