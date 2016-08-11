using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
