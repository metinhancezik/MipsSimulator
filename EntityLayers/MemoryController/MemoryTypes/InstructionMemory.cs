using InstructionLayer.InstructionTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLayer.Concrete.MemoryTypes
{
    public class InstructionMemory : Memory
    {
        private List<Instruction> m_Data;
        private List<int> m_Data2;
        public InstructionMemory(int guardAddress, int capacity) :
            base(guardAddress, capacity)
        {

            m_Data = Enumerable.Repeat(new DummyTypeInstruction(), capacity).ToList<Instruction>();
            m_Data2 = Enumerable.Repeat(0, capacity).ToList<int>();
        }
        public List<Instruction> GetData
        {
            get
            {
                return m_Data;
            }
        }
        public bool InsertDataByAddress(int address, ref Instruction value)
        {
            Console.WriteLine($"Inserted to ins mem Line number {address}");
            if (address < 0 || address > Capacity)
                return false;
            m_Data[address] = value;

            m_Data2[address] = value.GetInstructionFormat;
            ProtectionAddress++;
            return true;
        }
        public Instruction GetDataByAddress(int address, out bool isSuccess)
        {
            isSuccess = (address >= 0 && address < Capacity && ProtectionAddress > address);
            if (isSuccess)
                return m_Data[address];
            else
                return m_Data[ProtectionAddress];
        }
        public List<Tuple<int, Instruction>> GetAllData()
        {
            List<Tuple<int, Instruction>> data = new List<Tuple<int, Instruction>>();
            for (int i = 0; i < m_Data.Count; i++)
            {
                data.Add(new Tuple<int, Instruction>(m_Data2[i], m_Data[i]));
            }
            return data;
        }

    }
}
