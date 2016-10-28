using PCB.NET.Domain.Model.WorkshopPCB.Map;
using System.Collections.Generic;

namespace PCB.NET.Web.Areas.PCB.Models.MapViewModel
{
    public class MapListViewModel
    {
        public IEnumerable<Map> Map { get; set; }
        public ListView ListView { get; set; }
    }
}