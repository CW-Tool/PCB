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
        public string ValueItem { get; set; }
        public RatedItem? RatedItem { get; set; }
        public string DescriptionItem { get; set; }
        [Required]
        public int CountItem { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }

        [Required]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        [Required]
        public int SizeId { get; set; }
        public virtual Size Size { get; set; }


        public virtual ICollection<HangingItemMap> HangingItemMaps { get; set; }
    }
}
