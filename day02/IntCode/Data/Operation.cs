using System;
using System.Collections.Generic;
using System.Text;

namespace day02.IntCode.Data
{
    public class Operation
    {
        public Instruction Instruction { get; set; }

        public static implicit operator Operation(int opcode)
        {
            int ab = opcode % 100;

            return new Operation
            {
                Instruction = ab.ToInstruction()
            };
        }
    }
}
