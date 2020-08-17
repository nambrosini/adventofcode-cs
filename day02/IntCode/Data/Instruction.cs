using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace day02.IntCode.Data
{
    public enum Instruction
    {
        Add = 1,
        Multiply = 2,
        Exit = 99
    }

    public static class IntExtension
    {
        public static Instruction ToInstruction(this int val)
        {
            switch (val)
            {
                case 1:
                    return Instruction.Add;
                case 2:
                    return Instruction.Multiply;
                case 99:
                    return Instruction.Exit;
                default:
                    throw new ArgumentException("OpCode not recognized");

            }
        }
    }
}
