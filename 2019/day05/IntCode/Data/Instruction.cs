using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace day05.IntCode.Data
{
    public enum Instruction
    {
        Add = 1,
        Multiply = 2,
        Save = 3,
        Out = 4,
        Jit = 5,
        Jif = 6,
        Lt = 7,
        Eq = 8,
        Exit = 99
    }
}
