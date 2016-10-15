using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Employee
{
    [Table("Position", Schema = "employee")]
    public class Position
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PositionEmp { get; set; }


        public virtual ICollection<Employee> Employee { get; set; }
    }
}
