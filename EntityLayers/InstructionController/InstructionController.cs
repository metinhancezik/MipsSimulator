using InstructionLayer.InstructionTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InstructionLayer.InstructionControllers.EnumInstructionParameters;
using static InstructionLayer.InstructionControllers.EnumInstructionRawTypes;
using static InstructionLayer.InstructionTypes.EnumInstructionTypes;

namespace InstructionLayer.InstructionControllers
{
    public class InstructionController
    {
        public struct InstructionProperty
        {
            public RawInstructionInitType Module_RawInstructionInitType;
            public InstructionType Module_Type;
            public int Module_ResultOPCode;
            public List<InstructionParams> Module_InstructionParameters;
            public int Module_OPCode;
            public int Module_Funct;
            public InstructionProperty(InstructionType instructionType, int OPCode, int funct, RawInstructionInitType rawInstructionInitType, List<InstructionParams> instructionParams)
            {
                Module_Type = instructionType;
                Module_OPCode = OPCode;
                Module_Funct = funct;
                Module_RawInstructionInitType = rawInstructionInitType;
                Module_InstructionParameters = instructionParams;
                Module_ResultOPCode = (funct << 6) + Module_OPCode;
            }
        }
        public class InstructionFactory
        {

            private static InstructionFactory Module_Instance;
            private InstructionFactory()
            {
                m_InstructionPropertyMap = new Dictionary<string, InstructionProperty>
            {
                // R TYPES

                { "add" ,
                    new InstructionProperty(InstructionType.R,0, 32, RawInstructionInitType.RIP_TYPE_1,
                    new List<InstructionParams> {InstructionParams.IP_INSTRUCTION_NAME, InstructionParams.IP_REGISTER, InstructionParams.IP_REGISTER, InstructionParams.IP_REGISTER })
                },

                {
                    "sub",
                    new InstructionProperty(InstructionType.R,0,34,RawInstructionInitType.RIP_TYPE_1,
                    new List<InstructionParams>{InstructionParams.IP_INSTRUCTION_NAME,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER})
                },

                {
                    "and",
                    new InstructionProperty(InstructionType.R,0,36,RawInstructionInitType.RIP_TYPE_1,
                    new List<InstructionParams>{InstructionParams.IP_INSTRUCTION_NAME,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER})
                },

                {
                    "or",
                    new InstructionProperty(InstructionType.R,0,37,RawInstructionInitType.RIP_TYPE_1,
                    new List<InstructionParams>{InstructionParams.IP_INSTRUCTION_NAME,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER})
                },

                {
                    "xor",
                    new InstructionProperty(InstructionType.R,0,38,RawInstructionInitType.RIP_TYPE_1,
                    new List<InstructionParams>{InstructionParams.IP_INSTRUCTION_NAME,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER})
                },

                {
                    "slt",
                    new InstructionProperty(InstructionType.R,0,42,RawInstructionInitType.RIP_TYPE_1,
                    new List<InstructionParams>{InstructionParams.IP_INSTRUCTION_NAME,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER})
                },

                {
                    "sll",
                    new InstructionProperty(InstructionType.R,0,0,RawInstructionInitType.RIP_TYPE_1,
                    new List<InstructionParams>{InstructionParams.IP_INSTRUCTION_NAME,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER})
                },

                {
                    "srl",
                    new InstructionProperty(InstructionType.R,0,2,RawInstructionInitType.RIP_TYPE_1,
                    new List<InstructionParams>{InstructionParams.IP_INSTRUCTION_NAME,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER})
                },

                {
                    "sra",
                    new InstructionProperty(InstructionType.R,0,3,RawInstructionInitType.RIP_TYPE_1,
                    new List<InstructionParams>{InstructionParams.IP_INSTRUCTION_NAME,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER})
                },

                {
                    "jr",
                    new InstructionProperty(InstructionType.R,0,8,RawInstructionInitType.RIP_TYPE_3,
                    new List<InstructionParams>{InstructionParams.IP_INSTRUCTION_NAME,InstructionParams.IP_REGISTER})
                },

                {
                    "mult",
                    new InstructionProperty(InstructionType.R,0,40,RawInstructionInitType.RIP_TYPE_1,
                    new List<InstructionParams>{InstructionParams.IP_INSTRUCTION_NAME,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER})
                },

                {
                    "div",
                    new InstructionProperty(InstructionType.R,0,26,RawInstructionInitType.RIP_TYPE_1,
                    new List<InstructionParams>{InstructionParams.IP_INSTRUCTION_NAME,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER,InstructionParams.IP_REGISTER})
                },

                // I TYPES

                { "addi",
                new InstructionProperty(InstructionType.I,8,0,RawInstructionInitType.RIP_TYPE_2,
                new List<InstructionParams> { InstructionParams.IP_INSTRUCTION_NAME, InstructionParams.IP_REGISTER, InstructionParams.IP_REGISTER , InstructionParams.IP_IMMEDIATE})
                },

                { "andi",
                new InstructionProperty(InstructionType.I,12,0,RawInstructionInitType.RIP_TYPE_2,
                new List<InstructionParams> { InstructionParams.IP_INSTRUCTION_NAME, InstructionParams.IP_REGISTER, InstructionParams.IP_REGISTER , InstructionParams.IP_IMMEDIATE})
                },

                { "ori",
                new InstructionProperty(InstructionType.I,13,0,RawInstructionInitType.RIP_TYPE_2,
                new List<InstructionParams> { InstructionParams.IP_INSTRUCTION_NAME, InstructionParams.IP_REGISTER, InstructionParams.IP_REGISTER , InstructionParams.IP_IMMEDIATE})
                },

                { "slti",
                new InstructionProperty(InstructionType.I,10,0,RawInstructionInitType.RIP_TYPE_2,
                new List<InstructionParams> { InstructionParams.IP_INSTRUCTION_NAME, InstructionParams.IP_REGISTER, InstructionParams.IP_REGISTER , InstructionParams.IP_IMMEDIATE})
                },

                { "beq",
                new InstructionProperty(InstructionType.I,4, 0,RawInstructionInitType.RIP_TYPE_6,
                new List<InstructionParams> { InstructionParams.IP_INSTRUCTION_NAME, InstructionParams.IP_REGISTER, InstructionParams.IP_REGISTER , InstructionParams.IP_LABEL})
                },

                { "bne",
                new InstructionProperty(InstructionType.I,5, 0,RawInstructionInitType.RIP_TYPE_6,
                new List<InstructionParams> { InstructionParams.IP_INSTRUCTION_NAME, InstructionParams.IP_REGISTER, InstructionParams.IP_REGISTER , InstructionParams.IP_LABEL})
                },

                { "lw",
                new InstructionProperty(InstructionType.I,35,0,RawInstructionInitType.RIP_TYPE_4,
                new List<InstructionParams> { InstructionParams.IP_INSTRUCTION_NAME, InstructionParams.IP_REGISTER, InstructionParams.IP_IMMEDIATE , InstructionParams.IP_REGISTER})
                },

                { "sw",
                new InstructionProperty(InstructionType.I,43, 0,RawInstructionInitType.RIP_TYPE_4,
                new List<InstructionParams> { InstructionParams.IP_INSTRUCTION_NAME, InstructionParams.IP_REGISTER, InstructionParams.IP_IMMEDIATE , InstructionParams.IP_IMMEDIATE})
                },

                { "lb",
                new InstructionProperty(InstructionType.I,36, 0,RawInstructionInitType.RIP_TYPE_4,
                new List<InstructionParams> { InstructionParams.IP_INSTRUCTION_NAME, InstructionParams.IP_REGISTER, InstructionParams.IP_IMMEDIATE , InstructionParams.IP_IMMEDIATE})
                },

                { "sb",
                new InstructionProperty(InstructionType.I,72, 0,RawInstructionInitType.RIP_TYPE_4,
                new List<InstructionParams> { InstructionParams.IP_INSTRUCTION_NAME, InstructionParams.IP_REGISTER, InstructionParams.IP_IMMEDIATE , InstructionParams.IP_IMMEDIATE})
                },

                { "lui",
                new InstructionProperty(InstructionType.I,15,0,RawInstructionInitType.RIP_TYPE_2,
                new List<InstructionParams> { InstructionParams.IP_INSTRUCTION_NAME, InstructionParams.IP_REGISTER, InstructionParams.IP_IMMEDIATE})
                },

  




                // J TYPES
                { "j",

                new InstructionProperty(InstructionType.J,2, 0,RawInstructionInitType.RIP_TYPE_7,
                new List<InstructionParams> { InstructionParams.IP_INSTRUCTION_NAME, InstructionParams.IP_REGISTER, InstructionParams.IP_LABEL})
                },

                { "jal",
                new InstructionProperty(InstructionType.J,3, 0,RawInstructionInitType.RIP_TYPE_7,
                new List<InstructionParams> { InstructionParams.IP_INSTRUCTION_NAME, InstructionParams.IP_REGISTER, InstructionParams.IP_LABEL})
                }

            };
            }

            public static InstructionFactory Instance
            {
                get
                {
                    if (Module_Instance == null)
                        Module_Instance = new InstructionFactory();
                    return Module_Instance;
                }
            }
            public Instruction GetInstruction(string name)
            {
                switch (m_InstructionPropertyMap[name].Module_Type)
                {
                    case InstructionType.R:
                        return new RTypeInstruction(name, InstructionType.R, m_InstructionPropertyMap[name].Module_ResultOPCode, 0); 
                        break;
                    case InstructionType.I:
                        return new ITypeInstruction(name, InstructionType.I, m_InstructionPropertyMap[name].Module_ResultOPCode);
                        break;
                    case InstructionType.J:
                        return new JTypeInstruction(name, InstructionType.J, m_InstructionPropertyMap[name].Module_ResultOPCode);
                        break;
                }
                
                return new RTypeInstruction(name, InstructionType.R, m_InstructionPropertyMap[name].Module_ResultOPCode, 0);
            }

            public InstructionProperty GetInstructionPropertyByName(string name)
            {
                return m_InstructionPropertyMap[name];
            }

            private Dictionary<string, InstructionProperty> m_InstructionPropertyMap;

        }

    }
}
