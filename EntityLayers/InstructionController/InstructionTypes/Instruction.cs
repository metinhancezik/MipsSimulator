using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InstructionLayer.InstructionTypes.EnumInstructionTypes;

namespace InstructionLayer.InstructionTypes
{
    public abstract class Instruction
    {
        private string Module_Name = default;
        private InstructionType Module_InstructionType;
        protected int Module_OPCode = default;
        protected int Module_InstructionFormat;
        public abstract int Execute();
        public abstract int Initialize(params int[] parameters);

        public Instruction(string name, InstructionType instructionType, int opCode, int instructionFormat)
        {
            Module_Name = name;
            Module_InstructionType = instructionType;
            Module_OPCode = opCode;
            Module_InstructionFormat = instructionFormat;
        }
        public string GetName
        {
            get => Module_Name;
            set => Module_Name = value;
        }
        public int GetInstructionFormat
        {
            get => Module_InstructionFormat;
        }
    }
}