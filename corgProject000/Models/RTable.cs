
using RegisterLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProject
{
    public class RTable
    {
        public string Name { get; set; }
        public int? Number { get; set; }
        public string Value { get; set; }

        public static List<RTable> initiliaze()
        {
            List<RTable> registers = new()
            {
                new RTable {Name ="$zero",Number = 0,Value = "0x00000000"},
                new RTable {Name ="$at",  Number = 1,Value = "0x00000000"},
                new RTable {Name ="$v0",Number = 2,Value = "0x00000000"},
                new RTable {Name ="$v1",Number = 3,Value = "0x00000000"},
                new RTable {Name ="$a0",Number = 4,Value = "0x00000000"},
                new RTable {Name ="$a1",Number = 5,Value = "0x00000000"},
                new RTable {Name ="$a2",Number = 6,Value = "0x00000000"},
                new RTable {Name ="$a3",Number = 7,Value = "0x00000000"},
                new RTable {Name ="$t0",Number = 8,Value = "0x00000000"},
                new RTable {Name ="$t1",Number = 9,Value = "0x00000000"},
                new RTable {Name ="$t2",Number = 10,Value = "0x00000000"},
                new RTable {Name ="$t3",Number = 11,Value = "0x00000000"},
                new RTable {Name ="$t4",Number = 12,Value = "0x00000000"},
                new RTable {Name ="$t5",Number = 13,Value = "0x00000000"},
                new RTable {Name ="$t6",Number = 14,Value = "0x00000000"},
                new RTable {Name ="$t7",Number = 15,Value = "0x00000000"},
                new RTable {Name ="$s0",Number = 16,Value = "0x00000000"},
                new RTable {Name ="$s1",Number = 17,Value = "0x00000000"},
                new RTable {Name ="$s2",Number = 18,Value = "0x00000000"},
                new RTable {Name ="$s3",Number = 19,Value = "0x00000000"},
                new RTable {Name ="$s4",Number = 20,Value = "0x00000000"},
                new RTable {Name ="$s5",Number = 21,Value = "0x00000000"},
                new RTable {Name ="$s6",Number = 22,Value = "0x00000000"},
                new RTable {Name ="$s7",Number = 23,Value = "0x00000000"},
                new RTable {Name ="$t8",Number = 24,Value = "0x00000000"},
                new RTable {Name ="$t9",Number = 25,Value = "0x00000000"},
                new RTable {Name ="$k0",Number = 26,Value = "0x00000000"},
                new RTable {Name ="$k1",Number = 27,Value = "0x00000000"},
                new RTable {Name ="$gp",Number = 28,Value = "0x00000000"},
                new RTable {Name ="$sp",Number = 29,Value = "0x00000000"},
                new RTable {Name ="$fp",Number = 30,Value = "0x00000000"},
                new RTable {Name ="$ra",Number = 31,Value = "0x00000000"},
                new RTable {Name ="$pc",Number = 32,Value = "0x00000000"},
            };
            return registers;
        }
        public static List<RTable> Refresh()
        {
            List<RTable> registers = new()
            {
                new RTable {Name ="$zero",Number = 0,Value = "0x" + (RegisterController.IsCreated.GetRegisterByIndex(0).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$at",  Number = 1,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(1).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$v0",Number = 2,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(2).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$v1",Number = 3,Value = "0x" + (RegisterController.IsCreated.GetRegisterByIndex(3).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$a0",Number = 4,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(4).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$a1",Number = 5,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(5).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$a2",Number = 6,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(6).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$a3",Number = 7,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(7).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$t0",Number = 8,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(8).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$t1",Number = 9,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(9).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$t2",Number = 10,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(10).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$t3",Number = 11,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(11).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$t4",Number = 12,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(12).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$t5",Number = 13,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(13).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$t6",Number = 14,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(14).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$t7",Number = 15,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(15).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$s0",Number = 16,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(16).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$s1",Number = 17,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(17).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$s2",Number = 18,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(18).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$s3",Number = 19,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(19).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$s4",Number = 20,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(20).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$s5",Number = 21,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(21).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$s6",Number = 22,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(22).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$s7",Number = 23,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(23).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$t8",Number = 24,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(24).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$t9",Number = 25,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(25).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$k0",Number = 26,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(26).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$k1",Number = 27,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(27).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$gp",Number = 28,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(28).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$sp",Number = 29,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(29).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$fp",Number = 30,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(30).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$ra",Number = 31,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(31).GetValue.ToString("X").PadLeft(8,'0'))},
                new RTable {Name ="$pc",Number = 32,Value =  "0x" + (RegisterController.IsCreated.GetRegisterByIndex(32).GetValue.ToString("X").PadLeft(8,'0'))},
            };
            return registers;
        }
    }
}
