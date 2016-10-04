using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.Warehouse.WorkshopPCB
{
    /// <summary>
    /// Hanging elements
    /// </summary>
    [Table("Hanging", Schema = "store")]
    public class Hanging
    {
        public Hanging()
        {
            BoardHanging = new HashSet<Board>();

        }
        [Key]
        public int HangingId { get; set; }
        [Required]
        public virtual Item Item { get; set; }
        [Required]
        public int Value { get; set; }
        [Required]
        public virtual RatedItem RatedItem { get; set; }
        [Required]
        public string DescriptionItem { get; set; }
        public virtual Size Size { get; set; }
        [Required]
        public int CountItem { get; set; }
        public DateTime? LastUpdate { get; set; }

        public virtual ICollection<Board> BoardHanging { get; set; }
    }
}
