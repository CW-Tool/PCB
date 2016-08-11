using PCB.NET.Domain.Model.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB.NET.Domain.Model.Map
{
    [Table("Map", Schema = "plan")]
    public class Map
    {
        [Key]
        public int MapId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Count Count { get; set; }


    }
}
