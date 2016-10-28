using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using System.Collections.Generic;

namespace PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel
{
    public class BoardListViewModel
    {
        public IEnumerable<Board> Board { get; set; }
        public ListView ListView { get; set; }
    }
}