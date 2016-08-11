using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.Warehouse
{
    [Table("GasBalloon", Schema = "store")]
    public class GasBalloon
    {
        [Key]
        public int BalloonId { get; set; }
        [Required]
        public int BalloonNumber { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
    }
}
