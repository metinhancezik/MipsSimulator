using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionLayer.InstructionControllers
{
    public class EnumInstructionParameters
    {
        public enum InstructionParams
        {
            IP_INSTRUCTION_NAME,
            IP_REGISTER,
            IP_IMMEDIATE,
            IP_LABEL
        }
    }
}
