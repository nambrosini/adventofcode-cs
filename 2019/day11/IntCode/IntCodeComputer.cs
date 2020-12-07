using day11.IntCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace day11.IntCode
{
    class IntCodeComputer
    {
        private readonly List<long> _memory;

        private int _address;

        private long? _input;

        private int _relativeBase;

        public IntCodeComputer(long[] memory, long? input)
        {
            this._memory = memory.ToList();
            this._address = 0;
            this._input = input;
            this._relativeBase = 0;
        }

        public long Step(int signal)
        {
            while (true)
            {
                Operation operation = this._memory[this._address];
                long p1, p2;

                switch (operation.Instruction)
                {
                    case Instruction.Add:
                        p1 = MemGet(operation.Mode1, 1);
                        p2 = MemGet(operation.Mode2, 2);

                        MemSet(operation.Mode3, 3, p1 + p2);

                        this._address += 4;
                        break;
                    case Instruction.Multiply:
                        p1 = MemGet(operation.Mode1, 1);
                        p2 = MemGet(operation.Mode2, 2);

                        MemSet(operation.Mode3, 3, p1 * p2);

                        this._address += 4;
                        break;
                    case Instruction.Save:
                        if (_input != null)
                        {
                            MemSet(operation.Mode1, 1, (int) _input);
                            _input = null;
                        } else
                        {
                            MemSet(operation.Mode1, 1, signal);
                        }
                        this._address += 2;
                        break;
                    case Instruction.Out:
                        long res = MemGet(operation.Mode1, 1);
                        this._address += 2;
                        return res;
                    case Instruction.Jit:
                        if (MemGet(operation.Mode1, 1) != 0)
                        {
                            this._address = (int) MemGet(operation.Mode2, 2);
                        }
                        else
                        {
                            this._address += 3;
                        }
                        break;
                    case Instruction.Jif:
                        if (MemGet(operation.Mode1, 1) == 0)
                        {
                            this._address = (int) MemGet(operation.Mode2, 2);
                        }
                        else
                        {
                            this._address += 3;
                        }
                        break;
                    case Instruction.Lt:
                        bool lt = MemGet(operation.Mode1, 1) < MemGet(operation.Mode2, 2);
                        MemSet(operation.Mode3, 3, Convert.ToInt32(lt));
                        this._address += 4;
                        break;
                    case Instruction.Eq:
                        bool eq = MemGet(operation.Mode1, 1) == MemGet(operation.Mode2, 2);
                        MemSet(operation.Mode3, 3, Convert.ToInt32(eq));
                        this._address += 4;
                        break;
                    case Instruction.Adj:
                        this._relativeBase += (int) MemGet(operation.Mode1, 1);
                        this._address += 2;
                        break;
                    case Instruction.Exit:
                        return -1;
                }
            }
        }

        private long MemGet(Mode mode, int offset)
        {
            return this._memory[ModeAddress(mode, offset)];
        }

        private void MemSet(Mode mode, int offset, long value)
        {
            this._memory[ModeAddress(mode, offset)] = value;
        }

        private int ModeAddress(Mode mode, int offset)
        {
            var addr = mode switch
            {
                Mode.Pos => (int)this._memory[this._address + offset],
                Mode.Imm => this._address + offset,
                Mode.Rel => (int)this._memory[this._address + offset] + this._relativeBase,
                _ => throw new System.Exception("Mode not recognized."),
            };

            ResizeMemory(addr);

            return addr;
        }

        private void ResizeMemory(int addr)
        {
            if (addr > this._memory.Count())
            {
                this._memory.AddRange(new long[addr]);
            }
        }
    }
}
