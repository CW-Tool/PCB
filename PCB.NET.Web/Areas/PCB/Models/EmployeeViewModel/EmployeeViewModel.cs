using PCB.NET.Domain.Model.WorkshopPCB.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCB.NET.Web.Areas.PCB.Models.EmployeeViewModel
{
    public class EmployeeListViewModel
    {
        public IEnumerable<Employee> Employee { get; set; }
        public ListView ListView { get; set; }
    }
}