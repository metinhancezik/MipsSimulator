using MemoryLayer.Concrete;
using RegisterLayer.Concrete;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLayer.IType
{
    public class ITypeFunctions
    {

        public static int Addi(in Registers Source, ref Registers Target, int Immediate)
        {
            Target.GetValue = Source.GetValue + Immediate;
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            Console.WriteLine("Addi function executed");
            return Target.GetValue;
        }
        public static int Ori(in Registers Source, ref Registers Target, int Immediate)
        {
            Target.GetValue = Source.GetValue | Immediate;
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Target.GetValue;
        }
        public static int Andi(in Registers Source, ref Registers Target, int Immediate)
        {
            Target.GetValue = Source.GetValue & Immediate;

            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Target.GetValue;
        }
        public static int Slti(in Registers Source, ref Registers Target, int Immediate)
        {
            Target.GetValue = Source.GetValue < Immediate ? 1 : 0;
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Target.GetValue;
        }
        public static int Bne(in Registers Source, ref Registers Target, int Immediate)
        {
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            if (Source.GetValue != Target.GetValue)
            {
                RegisterController.IsCreated.GetRegisterByIndex(32).GetValue = Immediate;
            }
            return RegisterController.IsCreated.GetRegisterByIndex(32).GetValue;
        }
        public static int Beq(in Registers Source, ref Registers Target, int Immediate)
        {
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            if (Source.GetValue == Target.GetValue)
            {
                RegisterController.IsCreated.GetRegisterByIndex(32).GetValue = Immediate;
            }
            return RegisterController.IsCreated.GetRegisterByIndex(32).GetValue;
        }
        public static int Sw(in Registers Source, ref Registers Target, int Immediate)
        {
            for (int i = 0; i < 4; i++)
            {
                MemoryController.IsCreated.InsertToDataMemoryByAddress((Source.GetValue + Immediate + i), (byte)(Target.GetValue >> (8 * i)));
            }
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Target.GetValue;
        }
        public static int Lw(in Registers Source, ref Registers Target, int Immediate)
        {
            bool isSuccess = false;
            for (int i = 0; i < 4; i++)
            {
                Target.GetValue += (int)(MemoryController.IsCreated.GetFromDataMemoryByAddress((Source.GetValue + Immediate + i), out isSuccess)) << (i * 8);
            }
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Target.GetValue;
        }
        public static int Lb(in Registers Source, ref Registers Target, int Immediate)
        {
            bool isSuccess = false;
            Target.GetValue += (int)(MemoryController.IsCreated.GetFromDataMemoryByAddress((Source.GetValue + Immediate), out isSuccess));
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Target.GetValue;
        }
        public static int Lui(in Registers Target, ref Registers Source, int Immediate)
        {
            bool isSuccess = false;
            for (int i = 2; i < 4; i++)
            {
                Target.GetValue += (int)(MemoryController.IsCreated.GetFromDataMemoryByAddress((Source.GetValue + Immediate + (i - 2)), out isSuccess)) << (i * 8);
            }
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Target.GetValue;
        }
        public static int Sb(in Registers Source, ref Registers Target, int Immediate)
        {
            MemoryController.IsCreated.InsertToDataMemoryByAddress((Source.GetValue + Immediate), (byte)(Target.GetValue));
            RegisterController.IsCreated.GetRegisterByIndex(32).GetValue += 1;
            return Target.GetValue;
        }
      
    }
}
