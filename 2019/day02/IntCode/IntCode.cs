using day02.IntCode.Data;

namespace day02.IntCode
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

        public int step()
        {
            while (true)
            {
                var instruction = memory[address].ToInstruction();
                int p1, p2;

                switch (instruction)
                {
                    case Instruction.Add:
                        p1 = memGet(1);
                        p2 = memGet(2);

                        memSet(3, p1 + p2);
                        break;
                    case Instruction.Multiply:
                        p1 = memGet(1);
                        p2 = memGet(2);

                        memSet(3, p1 * p2);
                        break;
                    case Instruction.Exit:
                        return this.memory[0];
                }

                this.address += 4;
            }
        }

        private int memGet(int offset)
        {
            return this.memory[this.memory[address + offset]];
        }

        private void memSet(int offset, int value)
        {
            this.memory[this.memory[this.address + offset]] = value;
        }
    }
}
