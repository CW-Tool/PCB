using PCB.NET.Domain.Model.WorkshopPCB.Employee;
using PCB.NET.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCB.NET.Web.Areas.PCB.Models.EmployeeViewModel
{
    public class EmployeeListViewModel
    {
        public IEnumerable<Employee> Employee { get; set; }
        public ListView ListView { get; set; }
    }

    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MidName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string DescriptionWorker { get; set; }

        [Required]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }


        public virtual ICollection<DoneWork> DoneWork { get; set; }
    }
}