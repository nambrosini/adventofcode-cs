using day08.Data;
using System;
using System.IO;
using System.Linq;

namespace day08
{
    class Program
    {

        static void Main(string[] args)
        {
            var input = File.ReadAllText(@"C:\Users\Nico Ambrosini\source\repos\adventofcode-cs\day08\input").Trim();

            Image image = new Image(input);

            Layer fewestZeroes = image.FewestZeroes();

            #region Part 1
            var res = fewestZeroes.Pixels.Count(p => p == 1) * fewestZeroes.Pixels.Count(p => p == 2);

            Console.WriteLine($"Part 1: {res}");
            #endregion

            #region Part 2
            Console.WriteLine($"Part 2: \n{image.Render()}");
            #endregion
        }
    }
}
