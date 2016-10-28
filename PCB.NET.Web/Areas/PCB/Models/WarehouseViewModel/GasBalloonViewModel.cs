using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using System.Collections.Generic;

namespace PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel
{
    public class GasBalloonListViewModel
    {
        public IEnumerable<GasBalloon> GasBalloon { get; set; }
        public ListView ListView { get; set; }
    }
}