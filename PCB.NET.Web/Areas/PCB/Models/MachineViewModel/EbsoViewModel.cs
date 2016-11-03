using PCB.NET.Domain.Model.WorkshopPCB.Machine;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCB.NET.Web.Areas.PCB.Models.MachineViewModel
{
    public class EbsoListViewModel
    {
        public IEnumerable<Ebso> Ebso { get; set; }
        public ListView ListView { get; set; }
    }

    public class EbsoViewModel
    {
        public int Id { get; set; }
        public virtual Board Board { get; set; }
        [Required]
        public int TimeSecond { get; set; }
        public string Description { get; set; }
    }
}