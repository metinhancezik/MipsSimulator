using InstructionLayer.InstructionTypes;
using MemoryLayer.Concrete;
using RegisterLayer.Concrete;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static InstructionLayer.InstructionControllers.EnumInstructionParameters;
using static InstructionLayer.InstructionControllers.EnumInstructionRawTypes;
using static InstructionLayer.InstructionControllers.InstructionController;

namespace BusinessLayers.ProjectController
{
    public class ProjeController
    {
        private string Model_TContent;
        private List<string> Model_Lines;
        private List<List<string>> Model_RawInsLines;
        private Dictionary<string, int> Model_LabMap;
        private bool Model_CheckAssemble;
        private static ProjeController Model_Instance;
        private ProjeController()
        {

            Model_Lines = new List<string>();

            Model_LabMap = new Dictionary<string, int>();
            Model_CheckAssemble = false;
        }
        public static ProjeController Instance
        {
            get
            {
                if (Model_Instance == null)
                {
                    Model_Instance = new ProjeController();
                }
                return Model_Instance;
            }

        }
        public bool Assemble(string textContent)
        {
            RegisterController.IsCreated.CreateRegister();
            MemoryController.IsCreated.Initialize();
            Model_TContent = textContent;
            Model_Lines = Parse_Content(textContent);
            for (int i = 0; i < Model_Lines.Count; ++i)
                Model_Lines[i] = BeReadyForString(Model_Lines[i]);

            Model_RawInsLines = new List<List<string>>();
            foreach (string line in Model_Lines)
                Model_RawInsLines.Add(Split_W(line));


            Assemble_Raw(Model_RawInsLines);
            Model_CheckAssemble = true;
            return true;
        }

        public void RunNextInstr(out bool isSuccess)
        {
            isSuccess = false;
            if (Model_CheckAssemble)
            {
               MemoryController.IsCreated.GetFromInstructionMemoryByAddress(RegisterController.IsCreated.GetRegisterByIndex(32).GetValue, out isSuccess).Execute();
            }

        }

        public bool CheckNextInstr()
        {
            bool isSuccess = false;
            if (Model_CheckAssemble)
            {
               MemoryController.IsCreated.GetFromInstructionMemoryByAddress(RegisterController.IsCreated.GetRegisterByIndex(32).GetValue, out isSuccess);
                return isSuccess;
            }
            return false;
        }
        private List<string> Parse_Content(string textContent)
        {
            return textContent.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private string BeReadyForString(string content)
        {
            return Regex.Replace(((content.Replace(",", " ")).Replace(")", " ")).Replace("(", " "), @"\s+", " ");
        }

        private List<string> Split_W(string content)
        {
            return content.Split(' ').ToList();
        }

        private void Assemble_Raw(List<List<string>> rawInstructions)
        {
            int rawInstructionCount;
            int counter = 0;

            foreach (List<string> rawInstruction in rawInstructions)
            {
                rawInstructionCount = rawInstruction.Count;
                Insrt_Lab(rawInstruction, ref counter);
                ++counter;
            }
            counter = 0;
            foreach (List<string> rawInstruction in rawInstructions)
            {
                rawInstructionCount = rawInstruction.Count;
                Check_Create(rawInstruction, ref counter);
                ++counter;
            }
        }

        private bool Insrt_Lab(List<string> rawInstruction, ref int lineNumber)
        {
            int rawInstructionCount = rawInstruction.Count;
            rawInstruction.RemoveAll(str => string.IsNullOrEmpty(str));
            if (rawInstruction.Count == 1)
            {
                Model_LabMap[rawInstruction[0].Replace(":", "")] = lineNumber;
                --lineNumber;
                return true;
            }

            return true;

        }
        private bool Check_Create(List<string> rawInstruction, ref int lineNumber)
        {
            int rawInstructionCount = rawInstruction.Count;
            rawInstruction.RemoveAll(str => string.IsNullOrEmpty(str));
            if (rawInstruction.Count == 1)
            {
                Model_LabMap[rawInstruction[0].Replace(":", "")] = lineNumber;
                --lineNumber;
                return true;
            }
            List<InstructionParams> requiredParams = Get_InstrctnPrm_Nme(rawInstruction[0]);
           

            // R type

            Instruction instruction = new DummyTypeInstruction();
            switch (Get_InitT(rawInstruction[0]))
            {
                case RawInstructionInitType.RIP_TYPE_1:

                    instruction = InstructionFactory.Instance.GetInstruction(rawInstruction[0]);
                    instruction.Initialize(Get_RegNum_Nme(rawInstruction[1]),
                                            Get_RegNum_Nme(rawInstruction[2]),
                                            Get_RegNum_Nme(rawInstruction[3]),
                                            0,
                                            Get_InstrctnFnc_Nme(rawInstruction[0])
                                           );


                    break;
                case RawInstructionInitType.RIP_TYPE_2:
                    instruction = InstructionFactory.Instance.GetInstruction(rawInstruction[0]);
                    instruction.Initialize(Get_RegNum_Nme(rawInstruction[1]),
                                            Get_RegNum_Nme(rawInstruction[2]),
                                            int.Parse(rawInstruction[3])
                                          );
                    break;
                case RawInstructionInitType.RIP_TYPE_3:
                    instruction = InstructionFactory.Instance.GetInstruction(rawInstruction[0]);
                    instruction.Initialize(0,
                                            Get_RegNum_Nme(rawInstruction[1]),
                                            0,
                                            0,
                                            Get_InstrctnFnc_Nme(rawInstruction[0])
                                          );
                    break;
                case RawInstructionInitType.RIP_TYPE_4: 
                    instruction = InstructionFactory.Instance.GetInstruction(rawInstruction[0]);
                    instruction.Initialize(Get_RegNum_Nme(rawInstruction[1]),
                                            Get_RegNum_Nme(rawInstruction[3]),
                                            int.Parse(rawInstruction[2])
                                          );
                    break;

                case RawInstructionInitType.RIP_TYPE_5:
                    instruction = InstructionFactory.Instance.GetInstruction(rawInstruction[0]);
                    instruction.Initialize(Get_RegNum_Nme(rawInstruction[1]),
                                            0,
                                            int.Parse(rawInstruction[2])
                                          );
                    break;

                case RawInstructionInitType.RIP_TYPE_6:
                    instruction = InstructionFactory.Instance.GetInstruction(rawInstruction[0]);
                    instruction.Initialize(Get_RegNum_Nme(rawInstruction[1]),
                                            Get_RegNum_Nme(rawInstruction[2]),
                                            GetAddrs(rawInstruction[3])
                    );
                    break;

                case RawInstructionInitType.RIP_TYPE_7:
                    instruction = InstructionFactory.Instance.GetInstruction(rawInstruction[0]);
                    instruction.Initialize(GetAddrs(rawInstruction[1]));
                    break;
            }

           MemoryController.IsCreated.InsertToInstructionMemoryByAddress(lineNumber, ref instruction);

            return true;
        }

        private int Get_RegNum_Nme(string name)
        {
            return RegisterController.IsCreated.GetRegisterInfoByName(name);
        }

        private List<InstructionParams> Get_InstrctnPrm_Nme(string name)
        {
            return InstructionFactory.Instance.GetInstructionPropertyByName(name).Module_InstructionParameters;
        }

        private int Get_InstrctnFnc_Nme(string name)
        {
            return InstructionFactory.Instance.GetInstructionPropertyByName(name).Module_Funct;
        }

        private RawInstructionInitType Get_InitT(string name)
        {
            return InstructionFactory.Instance.GetInstructionPropertyByName(name).Module_RawInstructionInitType;

        }

        private int GetAddrs(string name)
        {
            return Model_LabMap[name];
        }

  
    }
}
