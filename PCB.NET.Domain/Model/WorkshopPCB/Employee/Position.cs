using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Employee
{
    [Table("Position", Schema = "employee")]
    public class Position
    {
        [Key]
        [ForeignKey("Employee")]
        public int PositionId { get; set; }
        [Required]
        public string PositionEmployee { get; set; }

        [Required]
        public Employee Employee { get; set; }
    }
}
