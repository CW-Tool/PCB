using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.Warehouse
{
    [Table("MapSMD", Schema = "store")]
    public class MapSMD
    {
        [Required]
        public int BoardID { get; set; }
        [Required]
        public int SmdID { get; set; }
    }
}
