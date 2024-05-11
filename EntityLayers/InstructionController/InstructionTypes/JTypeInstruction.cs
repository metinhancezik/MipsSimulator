using FunctionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InstructionLayer.InstructionTypes.EnumInstructionTypes;

namespace InstructionLayer.InstructionTypes
{
    public class JTypeInstruction:Instruction
    {

        private int Model_Address = default;

        private delegate int Functionality(int address);

        private JTypeDelegate Model_Functionality;


        public JTypeInstruction(string name, InstructionType instructionType, int opCode) :
          base(name, instructionType, opCode, 0)
        {
   
            Model_Functionality = FunctionController.IsCreated.GetFunctionByKey(opCode) as JTypeDelegate;
        }

        public override int Execute()
        {
            return Model_Functionality(Model_Address);
        }
        int GetAddress
        {
            get => Model_Address;
        }
        public override int Initialize(params int[] parameters)
        {
            if (parameters.Length != 1)
                return -1;

            Model_Address = parameters[0];
            Module_InstructionFormat = (Module_OPCode << 26) + Model_Address;
            return 0;
        }

 

    }
}
