using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InstructionLayer.InstructionTypes.EnumInstructionTypes;

namespace InstructionLayer.InstructionTypes
{
    public class DummyTypeInstruction:Instruction
    {
        public DummyTypeInstruction() :
          base("Boş", InstructionType.DUMMY, -1, 0)
        {

        }
     
        public override int Initialize(params int[] parameters)
        {
            return -1;
        }
        public override int Execute()
        {
            return -1;
        }
    }
}
