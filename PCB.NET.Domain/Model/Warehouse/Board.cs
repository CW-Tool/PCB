using PCB.NET.Domain.Model.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB.NET.Domain.Model.Warehouse
{
    [Table("Warehouse", Schema = "store")]
    public class Board
    {
        public Board()
        {
            Counts = new HashSet<Count>();
        }

        [Key]
        public int BoardId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CountBoard { get; set; }
        public string Description { get; set; }

        public DateTime? LastUpdate { get; set; }

        public virtual MapBoardMap MapBoardMap { get; set; }
        public virtual ICollection<Count> Counts { get; set; }

    }
}
