using BusinessLayers.ProjectController;
using corgProject000.ViewModels;
using FormProject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace corgProject000.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            indexViewModel startModel = new() { registers = RTable.initiliaze(), dataMemories = DMTable.FetchMemory(), instructionMemories = IMTable.FetchMemory() };

            return View(startModel);
        }

        public IActionResult newe (){
            

             indexViewModel startModel = new() { registers = RTable.initiliaze(), dataMemories = DMTable.FetchMemory(), instructionMemories = IMTable.FetchMemory() };
            return Json(startModel);
        }



      

   


        public IActionResult list(int isClicked, string assemblyCode, int LineNumbers)
        {
            TempData["LineNumber"] = LineNumbers;
            if (isClicked == 1)
            {
                
                ProjeController.Instance.Assemble(assemblyCode);
                indexViewModel startModel = new indexViewModel()
                {
                    registers = RTable.initiliaze(),
                    dataMemories = DMTable.FetchMemory(),
                    instructionMemories = IMTable.FetchMemory()
                };

                int assembled = 1;
                TempData["MyData"] = assembled;

                // İşlemler tamamlandıktan sonra startModel'i geri döndürüyoruz, tabii Json yönetmiyle döndürüyoruz ki ajax ile veriyi alıp tabloya aktaralım

                return Json(startModel);
            }

            return View();
        }

        public IActionResult RunAll( )
        {
            int rowCount = (int)TempData["LineNumber"];
            int isAssembled = (int)TempData["MyData"];

            if (isAssembled == 1)
            {
               
                bool success;
 
                for (int i = 0; ; i++)
                {
                    if (ProjeController.Instance.CheckNextInstr())
                    {
                        ProjeController.Instance.RunNextInstr(out success);
                    }
                    else
                    {
                        break;
                    }

                }
                indexViewModel startModel = new() { registers = RTable.Refresh(), dataMemories = DMTable.FetchMemory(), instructionMemories = IMTable.FetchMemory() };
                isAssembled = 0;

                return Json(startModel);
            }
            return Json(null);
        }


        public IActionResult RunStepByStep()
        {
            bool success;
            if (ProjeController.Instance.CheckNextInstr())
            {
                ProjeController.Instance.RunNextInstr(out success);
            }
            indexViewModel startModel = new() { registers = RTable.Refresh(), dataMemories = DMTable.FetchMemory(), instructionMemories = IMTable.FetchMemory() };
            return Json(startModel);
        }
    }
}

