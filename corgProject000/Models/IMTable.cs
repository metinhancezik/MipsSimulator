
using InstructionLayer.InstructionTypes;
using MemoryLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProject
{
    public class IMTable
    {
        public IMTable(string address, string memoryValue, string instructionName)
        {
            Address = address;
            MemoryValue = memoryValue;
            InstructionName = instructionName;
        }

        public string InstructionName { get; set; }
        public string Address { get; set; }
        public string MemoryValue { get; set; }

        public static List<IMTable> FetchMemory()
        {
            List<IMTable> dataMemories = new List<IMTable>();
            int counter = 0;
            foreach (Tuple<int,Instruction> data in MemoryController.IsCreated.GetInstructionMemory())
                dataMemories.Add(new IMTable("0x" + (counter++).ToString("X").PadLeft(8, '0'),"0x" + data.Item1.ToString("X").PadLeft(8,'0') ,data.Item2.GetName));
            return dataMemories;
        }
    }
}
