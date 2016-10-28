using PCB.NET.Domain.Model.WorkshopPCB.Machine;
using System.Collections.Generic;

namespace PCB.NET.Web.Areas.PCB.Models.MachineViewModel
{
    public class EbsoListViewModel
    {
        public IEnumerable<Ebso> Ebso { get; set; }
        public ListView ListView { get; set; }
    }
}