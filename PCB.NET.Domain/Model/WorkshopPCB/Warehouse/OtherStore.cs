using PCB.NET.Domain.Model.WorkshopPCB.Employee;
using PCB.NET.Domain.Model.WorkshopPCB.Machine;
using PCB.NET.Domain.Model.WorkshopPCB.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Warehouse
{
    [Table("OtherStore", Schema = "store")]
    public class OtherStore
    {
        [Key]
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

        [Required]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
