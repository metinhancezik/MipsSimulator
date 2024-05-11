using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static RegisterLayer.Concrete.EnumRegisterTypes;

namespace RegisterLayer.Concrete
{
    public class Registers
    {
        private string RegName;
        private int RegNumber;
        private string Name = default;
        private int Value = 0;
        private EnumRegisterTypes.RegisterType RegType;
        private EnumRegisterTypes.RegisterTypeProtected RegTypeProtected;

        public Registers(string RegisterName,int RegisterNumber, EnumRegisterTypes.RegisterType registerType, EnumRegisterTypes.RegisterTypeProtected registerTypeProtected)
        {
          RegName=RegisterName;
            RegNumber=RegisterNumber;
            RegType=registerType;
            RegTypeProtected=registerTypeProtected;
        }

        public int GetValue
        {
            get => Value;
            set => Value = value;
        }

        public string GetName
        {
            get => RegName;     
        }


    }
}
