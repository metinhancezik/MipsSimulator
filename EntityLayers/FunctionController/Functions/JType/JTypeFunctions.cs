using RegisterLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLayer.JType
{
    public class JTypeFunctions
    {
        public static int Jump(int JAddress)
        {
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue = JAddress;
            return JAddress;
        }
        public static int Jal(int JAddress)
        {
            RegisterController.IsCreated.GetRegisterByIndex(31).GetValue = RegisterController.IsCreated.GetRegisterByIndex(32).GetValue + 1; 
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue = JAddress;
            return JAddress;
        }
    }
}
