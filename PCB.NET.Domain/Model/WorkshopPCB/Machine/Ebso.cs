using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Machine
{
    [Table("Ebso", Schema = "machine")]
    public class Ebso
    {
        [Key]
        [ForeignKey("Board")]
        public int Id { get; set; }
        public virtual Board Board { get; set; }
        [Required]
        public int TimeSecond { get; set; }
        public string Description { get; set; }
    }
}
