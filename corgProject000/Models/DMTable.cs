
using MemoryLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProject
{
    public class DMTable
    {

        public DMTable(string address, byte memoryValue)
        {
            Address = address;
            MemoryValue = memoryValue;
        }

        public string Address { get; set; }
        public byte MemoryValue { get; set; }

        public static List<DMTable> FetchMemory()
        {
            List<DMTable> dataMemories = new List<DMTable>();
            int counter = 0;
            foreach(byte data in MemoryController.IsCreated.GetDataMemory())
                dataMemories.Add(new DMTable ( "0x"+ (counter++).ToString("X").PadLeft(8, '0'), data ));

            return dataMemories;
        }
    }
}
