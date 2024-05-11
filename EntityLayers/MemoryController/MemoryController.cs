using InstructionLayer.InstructionTypes;
using MemoryLayer.Concrete.MemoryTypes;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLayer.Concrete
{
    public class MemoryController
    {
        private InstructionMemory Model_InstructionMemory;
        private DataMemory Model_DataMemory;
        private MemoryController()
        {
            Initialize();
        }
        public void Initialize()
        {
            Model_InstructionMemory = new InstructionMemory(0, 1024); 
            Model_DataMemory = new DataMemory(0, 1024); 
        }
        private static MemoryController Model_Instance;
        public static MemoryController IsCreated
        {
            get
            {
                if (Model_Instance == null)
                    Model_Instance = new MemoryController();
                return Model_Instance;
            }
        }

        public List<Tuple<int, Instruction>> GetInstructionMemory()
        {
            return Model_InstructionMemory.GetAllData();
        }

        public byte GetFromDataMemoryByAddress(int address, out bool isSuccess)
        {
            return Model_DataMemory.GetDataByAddress(address, out isSuccess);
        }
        public bool InsertToDataMemoryByAddress(int address, byte value)
        {
            return Model_DataMemory.InsertDataByAddress(address, value);
        }

        public bool InsertToInstructionMemoryByAddress(int address, ref Instruction value)
        {
            return Model_InstructionMemory.InsertDataByAddress(address, ref value);
        }
        public Instruction GetFromInstructionMemoryByAddress(int address, out bool isSucces)
        {
            return Model_InstructionMemory.GetDataByAddress(address, out isSucces);
        }

        public List<byte> GetDataMemory()
        {
            return Model_DataMemory.GetAllData();
        }


  




    }
}
