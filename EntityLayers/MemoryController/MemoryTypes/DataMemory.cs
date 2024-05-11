using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLayer.Concrete.MemoryTypes
{
    public class DataMemory : Memory
    {
        private List<byte> m_Data;
        public DataMemory(int address, int capacity) :
            base(address, capacity)
        {
            m_Data = Enumerable.Repeat((byte)0, capacity).ToList<byte>();
        }
        public List<byte> GetData
        {
            get
            {
                return m_Data;
            }
        }
        public bool InsertDataByAddress(int address, byte value)
        {
            if (address < 0 || address > Capacity)
                return false;
            m_Data[address] = value;
            return true;
        }
        public byte GetDataByAddress(int address, out bool isSuccess)
        {
            isSuccess = (address >= 0 && address < Capacity);
            if (isSuccess)
                return m_Data[address];
            else
                return 0;
        }

        public List<byte> GetAllData()
        {
            return m_Data;
        }

   
     
    }
}
