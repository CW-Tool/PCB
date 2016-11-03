using PCB.NET.Domain.Model.WorkshopPCB.Employee;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCB.NET.Web.Areas.PCB.Models.EmployeeViewModel
{
    public class DoneWorkListViewModel
    {
        public IEnumerable<DoneWork> DoneWork { get; set; }
        public ListView ListView { get; set; }
    }

    public class DoneWorkViewModel
    {
        public int DoneId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Description { get; set; }


        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int BoardId { get; set; }


        public virtual Board Board { get; set; }
        public virtual Employee Employee { get; set; }
    }
}