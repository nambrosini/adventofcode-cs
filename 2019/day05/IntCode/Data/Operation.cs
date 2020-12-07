using System;
using System.Collections.Generic;
using System.Text;

namespace day05.IntCode.Data
{
    public class Operation
    {
        public Instruction Instruction { get; set; }
        public Mode Mode1 { get; set; }
        public Mode Mode2 { get; set; }
        public Mode Mode3 { get; set; }

        public Operation(Instruction instruction, Mode mode1, Mode mode2, Mode mode3)
        {
            Instruction = instruction;
            Mode1 = mode1;
            Mode2 = mode2;
            Mode3 = mode3;
        }

        public static implicit operator Operation(int opcode)
        {
            Instruction de = (Instruction) (opcode % 100);
            Mode c = (Mode) (opcode / 100 % 10);
            Mode b = (Mode) (opcode / 1000 % 10);
            Mode a = (Mode) (opcode / 10000 % 10);

            return new Operation(de, c, b, a);
        }
    }
}
