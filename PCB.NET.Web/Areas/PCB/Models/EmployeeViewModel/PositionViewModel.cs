using PCB.NET.Domain.Model.WorkshopPCB.Employee;
using PCB.NET.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCB.NET.Web.Areas.PCB.Models.EmployeeViewModel
{
    public class PositionListViewModel
    {
        public IEnumerable<Position> Position { get; set; }
        public ListView ListView { get; set; }
    }

    public class PositionViewModel
    {
        public int Id { get; set; }
        [Required]
        public string PositionEmp { get; set; }


        public virtual ICollection<Employee> Employee { get; set; }
    }
}