using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLayer.Concrete.MemoryTypes
{
    public abstract class Memory
    {
         protected int ProtectionAddress;
         protected int Capacity;
        public Memory(int guardAddress, int capacity)
        {
            ProtectionAddress = guardAddress;
            Capacity = capacity;
        }
        public int GetAddress
        {
            get => ProtectionAddress;
            set => ProtectionAddress = value;  
        }
        public int GetCapacity
        {
            get => Capacity;
            set => Capacity = value;
        }
    }
}
