using System;
using System.Collections.Generic;
using System.Text;

namespace Day08
{
    class GameConsole
    {
        public int Accumulator { get; set; }
        public List<int> Visited { get; set; }
        public List<Instruction> Instructions { get; set; }
        private int _pointer;

        public GameConsole(List<Instruction> instructions)
        {
            this.Instructions = instructions;
            this.Accumulator = 0;
            Visited = new List<int>();
            _pointer = 0;
        }

        public int RunPart1()
        {
            while (!Visited.Contains(_pointer))
            {
                var instruction = Instructions[_pointer];
                Visited.Add(_pointer);

                switch (instruction.Name)
                {
                    case InstructionName.Acc:
                        Accumulator += instruction.Value;
                        _pointer++;
                        break;
                    case InstructionName.Jmp:
                        _pointer += instruction.Value;
                        break;
                    case InstructionName.Nop:
                        _pointer++;
                        break;
                }
            }

            return Accumulator;
        }

        public int? RunPart2()
        {
            while (_pointer < Instructions.Count && !Visited.Contains(_pointer))
            {
                var instruction = Instructions[_pointer];
                Visited.Add(_pointer);

                switch (instruction.Name)
                {
                    case InstructionName.Acc:
                        Accumulator += instruction.Value;
                        _pointer++;
                        break;
                    case InstructionName.Jmp:
                        _pointer += instruction.Value;
                        break;
                    case InstructionName.Nop:
                        _pointer++;
                        break;
                }
            }

            if (_pointer >= Instructions.Count)
            {
                return Accumulator;
            } else
            {
                return null;
            }
        }
    }
}
