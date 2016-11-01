using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Models;
using System.Collections.Generic;

namespace PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel
{
    public class OtherStoreListViewModel
    {
        public IEnumerable<OtherStore> OtherStore { get; set; }
        public ListView ListView { get; set; }
    }
}