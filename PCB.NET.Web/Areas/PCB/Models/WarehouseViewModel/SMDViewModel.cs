using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel
{
    public class SMDListViewModel
    {
        public IEnumerable<SMD> SMD { get; set; }
        public ListView ListView { get; set; }
    }
    public class SMDViewModel
    {
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