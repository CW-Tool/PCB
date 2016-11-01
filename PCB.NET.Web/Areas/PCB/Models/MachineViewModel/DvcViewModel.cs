using PCB.NET.Domain.Model.WorkshopPCB.Machine;
using PCB.NET.Web.Models;
using System.Collections.Generic;

namespace PCB.NET.Web.Areas.PCB.Models.MachineViewModel
{
    public class DvcListViewModel
    {
        public IEnumerable<Dvc> Dvc { get; set; }
        public ListView ListView { get; set; }
    }
}