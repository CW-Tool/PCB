using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Employee
{
    [Table("Worker", Schema = "employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MidName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DailyWorkComplete { get; set; }

        [Required]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }


        public virtual ICollection<DoneWork> DoneWork { get; set; }
    }
}
