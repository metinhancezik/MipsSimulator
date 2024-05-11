using FormProject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace corgProject000.ViewModels
{
    public class indexViewModel
    {
         public List<DMTable>? dataMemories { get; set; }
         public List<IMTable>? instructionMemories { get; set; }
         public List<RTable>?  registers { get; set; }
    }
}
