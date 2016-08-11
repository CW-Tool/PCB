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
    public class Hanging
    {
        [Key]
        public int HangingId { get; set; }
        [Required]
        public Item Item { get; set; }
        [Required]
        public int Value { get; set; }
        [Required]
        public RatedItem RatedItem { get; set; }
        [Required]
        public string DescriptionItem { get; set; }
        [Required]
        public int CountItem { get; set; }
        public DateTime? LastUpdate { get; set; }

        [Required]
        public virtual Board Board { get; set; }
    }
}
