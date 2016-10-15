using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Warehouse
{
    /// <summary>
    /// Class SMD elements.
    /// </summary>
    [Table("SMD", Schema = "store")]
    public class SMD
    {
        [Key]
        public int SMDId { get; set; }
        public string ValueItem { get; set; }
        public RatedItem? RatedItem { get; set; }
        public string DescriptionItem { get; set; }
        [Required]
        public int Feeder { get; set; }
        [Required]
        public int CountItem { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }

        [Required]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        [Required]
        public int PackagesId { get; set; }
        public virtual Package Packages { get; set; }


        public virtual ICollection<SMDItemMap> SMDItemMaps { get; set; }
    }
}
