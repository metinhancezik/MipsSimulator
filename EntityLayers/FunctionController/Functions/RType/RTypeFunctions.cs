using RegisterLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLayer.RType
{
    public class RTypeFunctions
    {
        public static int Add(in Registers Source, in Registers Target, ref Registers Destination, int Shamt, int Funct)
        {
            Destination.GetValue = Source.GetValue + Target.GetValue;
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Destination.GetValue;
        }

        public static int Sub(in Registers Source, in Registers Target, ref Registers Destination, int Shamt, int Funct)
        {
            Destination.GetValue = Source.GetValue - Target.GetValue;
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Destination.GetValue;
        }

        public static int Div(in Registers Source, in Registers Target, ref Registers Destination, int Shamt, int Funct)
        {
            Destination.GetValue = Source.GetValue / Target.GetValue;
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Destination.GetValue;
        }

        public static int Mult(in Registers Source, in Registers Target, ref Registers Destination, int Shamt, int Funct)
        {
            Destination.GetValue = Source.GetValue * Target.GetValue;
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Destination.GetValue;
        }

        public static int Or(in Registers Source, in Registers Target, ref Registers Destination, int Shamt, int Funct)
        {
            Destination.GetValue = Source.GetValue | Target.GetValue;
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Destination.GetValue;
        }

        public static int And(in Registers Source, in Registers Target, ref Registers Destination, int Shamt, int Funct)
        {
            Destination.GetValue = Source.GetValue & Target.GetValue;
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Destination.GetValue;
        }
      
        public static int Xor(in Registers Source, in Registers Target, ref Registers Destination, int Shamt, int Funct)
        {
            Destination.GetValue = Source.GetValue ^ Target.GetValue;
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Destination.GetValue;
        }

        public static int Sll(in Registers Source, in Registers Target, ref Registers Destination, int Shamt, int Funct)
        {
            Destination.GetValue = (int)((uint) Source.GetValue << Target.GetValue );
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Destination.GetValue;
        }

        public static int Slt(in Registers Source, in Registers Target, ref Registers Destination, int Shamt, int Funct)
        {
            Destination.GetValue = Source.GetValue < Target.GetValue ? 1 : 0;
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Destination.GetValue;
        }
     
        public static int Sra(in Registers Source, in Registers Target, ref Registers Destination, int Shamt, int Funct)
        {
            Destination.GetValue = Source.GetValue >> Target.GetValue;
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Destination.GetValue;
        }

        public static int Srl(in Registers Source, in Registers Target, ref Registers Destination, int Shamt, int Funct)
        {
            Destination.GetValue = (int)((uint)Source.GetValue >> Target.GetValue);
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Destination.GetValue;
        }
        public static int JumpRegister(in Registers Source, in Registers Target, ref Registers Destination, int Shamt, int Funct)
        {
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue = Source.GetValue;
            return RegisterController.IsCreated.GetRegisterByIndex(32).GetValue;
        }
    }
}
