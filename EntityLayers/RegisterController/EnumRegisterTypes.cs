using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterLayer.Concrete
{
    public class EnumRegisterTypes
    {
        public enum RegisterType
        {
            Reg_TheConstantValue0, Reg_AssemblerTemporary, Reg_ValuesforFunctionResultsandExpressionEvaluation, Reg_Arguments,
            Reg_Temporaries, Reg_SavedTemporaries, Reg_ReservedforOSKernel, Reg_GlobalPointer, Reg_StackPointer,
            Reg_FramePointer, Reg_ReturnAddress, Reg_ProgrammingCounter, Reg_Dummy
        }
       public enum RegisterTypeProtected
        {
            Reg_NotAvailable, Reg_No, Reg_Yes
        }
    }
}
