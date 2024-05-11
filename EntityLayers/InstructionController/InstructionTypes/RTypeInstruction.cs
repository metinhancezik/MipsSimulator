using FunctionLayer;
using RegisterLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InstructionLayer.InstructionTypes.EnumInstructionTypes;

namespace InstructionLayer.InstructionTypes
{
    public class RTypeInstruction:Instruction
    {
      
        private int Model_Destination = default;
        private int Model_Source = default;
        private int Model_Target = default;
        private int Model_Shamt = default;
        private int Model_Funct = default;
        private RTypeDelegate Model_Functionality;

        public RTypeInstruction(string name, InstructionType instructionType, int opCode, int funct) :
           base(name, instructionType, opCode, 0)
        {
            Model_Funct = funct;
            Model_Functionality = FunctionController.IsCreated.GetFunctionByKey(opCode) as RTypeDelegate;
        }
        public int GetSource
        {
            get => Model_Source;
        }

        public int GetTarget
        {
            get => Model_Target;
        }

        public int GetDestination
        {
            get => Model_Destination;
        }

        public int GetShamt
        {
            get => Model_Shamt;
        }
        public int GetFunct
        {
            get => Model_Funct;
        }
        public override int Execute()
        {
            ref Registers destination = ref RegisterController.IsCreated.GetRegisterByIndex(Model_Destination);
            ref Registers Source = ref RegisterController.IsCreated.GetRegisterByIndex(Model_Source);
            ref Registers Target = ref RegisterController.IsCreated.GetRegisterByIndex(Model_Target);
            return Model_Functionality(in Source, in Target, ref destination, Model_Shamt, Model_Funct);
        }
        public override int Initialize(params int[] parameters)
        {
            if (parameters.Length != 5)
                return -1;

            Model_Destination = parameters[0];
            Model_Source = parameters[1];
            Model_Target = parameters[2];
            Model_Shamt = parameters[3];
            Model_Funct = parameters[4];
            Module_InstructionFormat = (Module_OPCode << 26) + (Model_Source << 21) + (Model_Target << 16) + (Model_Destination << 11) + (Model_Shamt << 6) + Model_Funct;
            return 0;
        }

    }
}
