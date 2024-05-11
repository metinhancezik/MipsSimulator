using FunctionLayer.IType;
using FunctionLayer.JType;
using FunctionLayer.RType;
using RegisterLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLayer
{
    public delegate int RTypeDelegate(in Registers Source, in Registers Target, ref Registers Destination, int Shamt, int Funct); 

    public delegate int ITypeDelegate(in Registers Source, ref Registers Target, int Immediate);

    public delegate int JTypeDelegate(int address);

    public class FunctionController
    {
        private static FunctionController Module_Instance;
        public static FunctionController IsCreated
        {
            get
            {
                if (Module_Instance == null)
                    Module_Instance = new FunctionController();
                return Module_Instance;
            }
        }
        private Dictionary<int, Delegate> FunctionMapping;
        private FunctionController()
        {
            FunctionMapping = new Dictionary<int, Delegate>();

            //R TYPE Functions

            FunctionMapping[0x800] = (RTypeDelegate)(RTypeFunctions.Add);

            FunctionMapping[0x880] = (RTypeDelegate)(RTypeFunctions.Sub);

            FunctionMapping[0x0A00] = (RTypeDelegate)(RTypeFunctions.Mult);

            FunctionMapping[0x680] = (RTypeDelegate)(RTypeFunctions.Div);

            FunctionMapping[0x900] = (RTypeDelegate)(RTypeFunctions.And);

            FunctionMapping[0x940] = (RTypeDelegate)(RTypeFunctions.Or);

            FunctionMapping[0x980] = (RTypeDelegate)(RTypeFunctions.Xor);

            FunctionMapping[0xA80] = (RTypeDelegate)(RTypeFunctions.Slt);

            FunctionMapping[0x80] = (RTypeDelegate)(RTypeFunctions.Srl);

            FunctionMapping[0xC0] = (RTypeDelegate)(RTypeFunctions.Sra);

            FunctionMapping[0x0] = (RTypeDelegate)(RTypeFunctions.Sll);

            FunctionMapping[0x200] = (RTypeDelegate)(RTypeFunctions.JumpRegister);


            // I TYPE Functions

            FunctionMapping[0x8] = (ITypeDelegate)(ITypeFunctions.Addi);

            FunctionMapping[0xC] = (ITypeDelegate)(ITypeFunctions.Andi);

            FunctionMapping[0xD] = (ITypeDelegate)(ITypeFunctions.Ori);

            FunctionMapping[0x48] = (ITypeDelegate)(ITypeFunctions.Sb);

            FunctionMapping[0xF] = (ITypeDelegate)(ITypeFunctions.Lui);

            FunctionMapping[0xA] = (ITypeDelegate)(ITypeFunctions.Slti);

            FunctionMapping[0x24] = (ITypeDelegate)(ITypeFunctions.Lb);

            FunctionMapping[0x4] = (ITypeDelegate)(ITypeFunctions.Beq);

            FunctionMapping[5] = (ITypeDelegate)(ITypeFunctions.Bne);

            FunctionMapping[0x23] = (ITypeDelegate)(ITypeFunctions.Lw);

            FunctionMapping[0x2B] = (ITypeDelegate)(ITypeFunctions.Sw);

            // J TYPE Functions

            FunctionMapping[0x2] = (JTypeDelegate)(JTypeFunctions.Jump);

            FunctionMapping[0x3] = (JTypeDelegate)(JTypeFunctions.Jal);
        }
        public Delegate GetFunctionByKey(int ourKey)
        {
            return FunctionMapping[ourKey];
        }
    }
}
