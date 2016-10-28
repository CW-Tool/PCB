using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using System.Collections.Generic;

namespace PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel
{
    public class HangingListViewModel
    {
        public IEnumerable<Hanging> Hanging { get; set; }
        public ListView ListView { get; set; }
    }
}