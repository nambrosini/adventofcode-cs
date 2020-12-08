using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Day08
{

    [Serializable]
    class Instruction
    {
        public InstructionName Name { get; set; }
        public int Value { get; set; }

        public static implicit operator Instruction(string s)
        {
            var instruction = new Instruction();
            var split = s.Split(" ");
            var name = split[0];

            instruction.Name = name switch
            {
                "acc" => InstructionName.Acc,
                "jmp" => InstructionName.Jmp,
                _ => InstructionName.Nop,
            };
            instruction.Value = int.Parse(split[1]);

            return instruction;
        }

        internal Instruction Clone()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(ms, this);

            ms.Position = 0;
            object obj = bf.Deserialize(ms);
            ms.Close();

            return obj as Instruction;
        }
    }

    [Serializable]
    enum InstructionName
    {
        Jmp,
        Nop,
        Acc
    }
}
