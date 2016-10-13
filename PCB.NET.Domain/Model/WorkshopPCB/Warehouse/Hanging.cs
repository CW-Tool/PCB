using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Warehouse
{
    /// <summary>
    /// Hanging elements
    /// </summary>
    [Table("Hanging", Schema = "store")]
    public class Hanging
    {
        [Key]
        public int HangingId { get; set; }
        [Required]
        public Item Item { get; set; }
        [Required]
        public double? ValueItem { get; set; }
        [Required]
        public RatedItem? RatedItem { get; set; }
        [Required]
        public string DescriptionItem { get; set; }
        [Required]
        public int CountItem { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        [Required]
        public int SizeId { get; set; }
        [Required]
        public Size Size { get; set; }


        public virtual ICollection<HangingItem> HangingItems { get; set; }
    }
}
