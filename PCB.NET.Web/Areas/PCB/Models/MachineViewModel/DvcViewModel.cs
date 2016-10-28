using PCB.NET.Domain.Model.WorkshopPCB.Machine;
using System.Collections.Generic;

namespace PCB.NET.Web.Areas.PCB.Models.MachineViewModel
{
    public class DvcListViewModel
    {
        public IEnumerable<Dvc> Dvc { get; set; }
        public ListView ListView { get; set; }
    }
}