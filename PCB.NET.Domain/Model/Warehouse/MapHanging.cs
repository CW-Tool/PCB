using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.Warehouse
{
    [Table("MapHanging", Schema = "store")]
    public class MapHanging
    {
        [Required]
        public int BoardID { get; set; }
        [Required]
        public int HangingID { get; set; }
    }
}
