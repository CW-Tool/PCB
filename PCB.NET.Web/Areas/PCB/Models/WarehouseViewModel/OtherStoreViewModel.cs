using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel
{
    public class OtherStoreListViewModel
    {
        public IEnumerable<OtherStore> OtherStore { get; set; }
        public ListView ListView { get; set; }
    }
    public class OtherStoreViewModel
    {
        public int OtherStoreId { get; set; }
        public double ValueItemOne { get; set; }
        public double ValueItemTwo { get; set; }
        public string DescriptionItemOne { get; set; }
        public string DescriptionItemTwo { get; set; }
        public string DescriptionItemThree { get; set; }
        [Required]
        public int CountItem { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
    }
}