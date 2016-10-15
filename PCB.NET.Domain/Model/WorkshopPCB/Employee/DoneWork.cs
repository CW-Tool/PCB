using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Employee
{
    [Table("DoneWork", Schema = "employee")]
    public class DoneWork
    {
        [Key]
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
