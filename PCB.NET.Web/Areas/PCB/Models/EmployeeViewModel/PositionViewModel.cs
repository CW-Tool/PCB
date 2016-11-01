using PCB.NET.Domain.Model.WorkshopPCB.Employee;
using PCB.NET.Web.Models;
using System.Collections.Generic;

namespace PCB.NET.Web.Areas.PCB.Models.EmployeeViewModel
{
    public class PositionListViewModel
    {
        public IEnumerable<Position> Position { get; set; }
        public ListView ListView { get; set; }
    }
}