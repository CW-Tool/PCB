using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel
{
    public class HangingListViewModel
    {
        public IEnumerable<Hanging> Hanging { get; set; }
        public ListView ListView { get; set; }
    }

    public class HangingViewModel
    {
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