using FunctionLayer;
using RegisterLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static InstructionLayer.InstructionTypes.EnumInstructionTypes;

namespace InstructionLayer.InstructionTypes
{
    public class ITypeInstruction : Instruction
    {
        private int Model_Source = default;
        private int Model_Target = default;
        private int Model_Immediate = default;
        private ITypeDelegate Model_Functionality;
        private delegate int Functionality(ref Registers Target, in Registers Source, int immediate);

        public ITypeInstruction(string name, InstructionType instructionType, int opCode) :
           base(name, instructionType, opCode, 0)
        {
            Model_Functionality = FunctionController.IsCreated.GetFunctionByKey(opCode) as ITypeDelegate;

        }

        public int GetImmediate
        {
            get => Model_Immediate;
        }
        public int GetSource
        {
            get => Model_Source;
        }

        public int GetTarget
        {
            get => Model_Target;
        }
        public override int Execute()
        {

            ref Registers Source = ref RegisterController.IsCreated.GetRegisterByIndex(Model_Source);

            ref Registers Target = ref RegisterController.IsCreated.GetRegisterByIndex(Model_Target);

            return Model_Functionality(in Source, ref Target, Model_Immediate);
        }
        public override int Initialize(params int[] parameters)
        {
            if (parameters.Length != 3)
                return -1;

            Model_Target = parameters[0];
            Model_Source = parameters[1];
            Model_Immediate = parameters[2];
            Module_InstructionFormat = (Module_OPCode << 26) + (Model_Source << 21) + (Model_Target << 16) + Model_Immediate;
            return 0;
        }




    }
}
