using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.Warehouse
{
    /// <summary>
    /// Gas Balloon
    /// </summary>
    [Table("GasBalloon", Schema = "store")]
    public class GasBalloon
    {
        [Key]
        public int GasBalloonId { get; set; }
        [Required]
        public string BalloonNumber { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
    }
}
