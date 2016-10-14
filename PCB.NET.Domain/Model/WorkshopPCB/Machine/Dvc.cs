using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Machine
{
    [Table("Dvc", Schema = "machine")]
    public class Dvc
    {
        [Key]
        [ForeignKey("Board")]
        public int Id { get; set; }
        [Required]
        public Board Board { get; set; }
        [Required]
        public int TimeSecond { get; set; }
        public string Description { get; set; }
    }
}