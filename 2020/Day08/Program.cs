using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day08
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Users\nicoa\source\repos\nambrosini\adventofcode-cs\2020\Day08\input")
                .Select(e => (Instruction) e)
                .ToList();

            var res1 = new GameConsole(input).RunPart1();

            Console.WriteLine($"Part 1: {res1}");

            var gameConsole = new GameConsole(input);

            var jmpOrNop = Enumerable.Range(0, input.Count)
                .Where(i => input[i].Name == InstructionName.Jmp || input[i].Name == InstructionName.Nop)
                .ToList();

            var counter = 0;

            int i;
            int? res;

            do
            {
                i = jmpOrNop[counter];

                List<Instruction> inputClone = input.Select(e => e.Clone()).ToList();

                if (inputClone[i].Name == InstructionName.Jmp)
                {
                    inputClone[i].Name = InstructionName.Nop;
                } else if (inputClone[i].Name == InstructionName.Nop)
                {
                    inputClone[i].Name = InstructionName.Jmp;
                }

                res = new GameConsole(inputClone).RunPart2();

                counter++;
            } while (res == null);

            Console.WriteLine($"Part 2: {res}");
        }
    }
}
