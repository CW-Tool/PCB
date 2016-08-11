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
    [Table("MapBoardMap", Schema = "plan")]
    public class MapBoardMap
    {
        [Required]
        public int MapId { get; set; }
        [Required]
        public int BoardId { get; set; }

    }
}
