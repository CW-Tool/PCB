using PCB.NET.Domain.Model.WorkshopPCB.Employee;
using PCB.NET.Web.Models;
using System.Collections.Generic;

namespace PCB.NET.Web.Areas.PCB.Models.EmployeeViewModel
{
    public class DoneWorkListViewModel
    {
        public IEnumerable<DoneWork> DoneWork { get; set; }
        public ListView ListView { get; set; }
    }
}