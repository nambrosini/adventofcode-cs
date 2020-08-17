using day05.IntCode.Data;
using System;

namespace day05.IntCode
{
    class IntCodeComputer
    {
        private int[] memory;

        private int address;

        public IntCodeComputer(int[] memory)
        {
            this.memory = memory;
            this.address = 0;
        }

        public int step(int input)
        {
            while (true)
            {
                Operation operation = this.memory[this.address];
                int p1, p2;

                switch (operation.Instruction)
                {
                    case Instruction.Add:
                        p1 = memGet(operation.Mode1, 1);
                        p2 = memGet(operation.Mode2, 2);

                        memSet(operation.Mode3, 3, p1 + p2);

                        this.address += 4;
                        break;
                    case Instruction.Multiply:
                        p1 = memGet(operation.Mode1, 1);
                        p2 = memGet(operation.Mode2, 2);

                        memSet(operation.Mode3, 3, p1 * p2);

                        this.address += 4;
                        break;
                    case Instruction.Save:
                        memSet(operation.Mode1, 1, input);
                        this.address += 2;
                        break;
                    case Instruction.Out:
                        p1 = memGet(operation.Mode1, 1);
                        this.address += 2;
                        return p1;
                    case Instruction.Jit:
                        if (memGet(operation.Mode1, 1) != 0)
                        {
                            this.address = memGet(operation.Mode2, 2);
                        }
                        else
                        {
                            this.address += 3;
                        }
                        break;
                    case Instruction.Jif:
                        if (memGet(operation.Mode1, 1) == 0)
                        {
                            this.address = memGet(operation.Mode2, 2);
                        }
                        else
                        {
                            this.address += 3;
                        }
                        break;
                    case Instruction.Lt:
                        bool lt = memGet(operation.Mode1, 1) < memGet(operation.Mode2, 2);
                        memSet(operation.Mode3, 3, Convert.ToInt32(lt));
                        this.address += 4;
                        break;
                    case Instruction.Eq:
                        bool eq = memGet(operation.Mode1, 1) == memGet(operation.Mode2, 2);
                        memSet(operation.Mode3, 3, Convert.ToInt32(eq));
                        this.address += 4;
                        break;
                    case Instruction.Exit:
                        return this.memory[0];
                }
            }
        }

        private int memGet(Mode mode, int offset)
        {
            return this.memory[modeAddress(mode, offset)];
        }

        private void memSet(Mode mode, int offset, int value)
        {
            this.memory[modeAddress(mode, offset)] = value;
        }

        private int modeAddress(Mode mode, int offset)
        {
            switch (mode)
            {
                case Mode.Pos:
                    return this.memory[this.address + offset];
                case Mode.Imm:
                    return this.address + offset;
                default:
                    throw new System.Exception("Mode not recognized.");
            }
        }
    }
}
