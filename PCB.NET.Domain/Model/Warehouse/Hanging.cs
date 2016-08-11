using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.Warehouse
{
    [Table("Hanging", Schema = "store")]
    public class Hanging
    {
        public Hanging()
        {
            MapHanging = new HashSet<Board>();

        }
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

        //[Required]
        //public virtual Board Board { get; set; }
        public virtual ICollection<Board> MapHanging { get; set; }
    }
}
