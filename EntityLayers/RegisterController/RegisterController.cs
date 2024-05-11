using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterLayer.Concrete
{
    public class RegisterController
    {
        Registers[] RegisterArray = new Registers[34];
        private static RegisterController m_IsCreated;
        private RegisterController()
        {
            CreateRegister();
        }
        public static RegisterController IsCreated
        {
            get
            {
                if (m_IsCreated == null)
                    m_IsCreated = new RegisterController();
                return m_IsCreated;
            }
        }
        public void CreateRegister()
        {
            RegisterArray[0] = new Registers("$zero", 0, EnumRegisterTypes.RegisterType.Reg_TheConstantValue0, EnumRegisterTypes.RegisterTypeProtected.Reg_NotAvailable);
            RegisterArray[1] = new Registers("$at", 1, EnumRegisterTypes.RegisterType.Reg_AssemblerTemporary, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[2] = new Registers("$v0", 2, EnumRegisterTypes.RegisterType.Reg_ValuesforFunctionResultsandExpressionEvaluation, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[3] = new Registers("$v1", 3, EnumRegisterTypes.RegisterType.Reg_ValuesforFunctionResultsandExpressionEvaluation, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[4] = new Registers("$a0", 4, EnumRegisterTypes.RegisterType.Reg_Arguments, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[5] = new Registers("$a1", 5, EnumRegisterTypes.RegisterType.Reg_Arguments, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[6] = new Registers("$a2", 6, EnumRegisterTypes.RegisterType.Reg_Arguments, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[7] = new Registers("$a3", 7, EnumRegisterTypes.RegisterType.Reg_Arguments, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[8] = new Registers("$t0", 8, EnumRegisterTypes.RegisterType.Reg_Temporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[9] = new Registers("$t1", 9, EnumRegisterTypes.RegisterType.Reg_Temporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[10] = new Registers("$t2", 10, EnumRegisterTypes.RegisterType.Reg_Temporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[11] = new Registers("$t3", 11, EnumRegisterTypes.RegisterType.Reg_Temporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[12] = new Registers("$t4", 12, EnumRegisterTypes.RegisterType.Reg_Temporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[13] = new Registers("$t5", 13, EnumRegisterTypes.RegisterType.Reg_Temporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[14] = new Registers("$t6", 14, EnumRegisterTypes.RegisterType.Reg_Temporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[15] = new Registers("$t7", 15, EnumRegisterTypes.RegisterType.Reg_Temporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[16] = new Registers("$s0", 16, EnumRegisterTypes.RegisterType.Reg_SavedTemporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_Yes);
            RegisterArray[17] = new Registers("$s1", 17, EnumRegisterTypes.RegisterType.Reg_SavedTemporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_Yes);
            RegisterArray[18] = new Registers("$s2", 18, EnumRegisterTypes.RegisterType.Reg_SavedTemporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_Yes);
            RegisterArray[19] = new Registers("$s3", 19, EnumRegisterTypes.RegisterType.Reg_SavedTemporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_Yes);
            RegisterArray[20] = new Registers("$s4", 20, EnumRegisterTypes.RegisterType.Reg_SavedTemporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_Yes);
            RegisterArray[21] = new Registers("$s5", 21, EnumRegisterTypes.RegisterType.Reg_SavedTemporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_Yes);
            RegisterArray[22] = new Registers("$s6", 22, EnumRegisterTypes.RegisterType.Reg_SavedTemporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_Yes);
            RegisterArray[23] = new Registers("$s7", 23, EnumRegisterTypes.RegisterType.Reg_SavedTemporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_Yes);
            RegisterArray[24] = new Registers("$t8", 24, EnumRegisterTypes.RegisterType.Reg_Temporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[25] = new Registers("$t9", 25, EnumRegisterTypes.RegisterType.Reg_Temporaries, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[26] = new Registers("$k0", 26, EnumRegisterTypes.RegisterType.Reg_ReservedforOSKernel, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[27] = new Registers("$k1", 27, EnumRegisterTypes.RegisterType.Reg_ReservedforOSKernel, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[28] = new Registers("$gp", 28, EnumRegisterTypes.RegisterType.Reg_GlobalPointer, EnumRegisterTypes.RegisterTypeProtected.Reg_Yes);
            RegisterArray[29] = new Registers("$sp", 29, EnumRegisterTypes.RegisterType.Reg_StackPointer, EnumRegisterTypes.RegisterTypeProtected.Reg_Yes);
            RegisterArray[30] = new Registers("$fp", 30, EnumRegisterTypes.RegisterType.Reg_FramePointer, EnumRegisterTypes.RegisterTypeProtected.Reg_Yes);
            RegisterArray[31] = new Registers("$ra", 31, EnumRegisterTypes.RegisterType.Reg_ReturnAddress, EnumRegisterTypes.RegisterTypeProtected.Reg_No);
            RegisterArray[32] = new Registers("PC", 32, EnumRegisterTypes.RegisterType.Reg_ProgrammingCounter, EnumRegisterTypes.RegisterTypeProtected.Reg_Yes);
        }


        public ref Registers GetRegisterByIndex(int index)
        {
            return ref RegisterArray[index];
        }

        public int GetRegisterInfoByName(string name)
        {
            int i = 0;

            foreach (Registers reg in RegisterArray)
            {
                if (reg.GetName==name)
                    break;
                ++i;
            }
            return i;
        }
    }
}
