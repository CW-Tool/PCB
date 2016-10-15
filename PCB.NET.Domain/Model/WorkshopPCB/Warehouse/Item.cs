using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Warehouse
{
    /// <summary>
    /// Class Item. Capacitor and etc.
    /// </summary>
    [Table("Item", Schema = "store")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string NameItem { get; set; }
        public string DescriptionItem { get; set; }


        public virtual ICollection<SMD> SMD { get; set; }
        public virtual ICollection<Hanging> Hanging { get; set; }
        public virtual ICollection<OtherStore> OtherStore { get; set; }
    }

    [Table("HangingItem", Schema = "store")]
    public class HangingItemMap
    {
        [Key]
        public int HangingItemId { get; set; }
        [Required]
        public string NameItem { get; set; }
        [Required]
        public int HangingId { get; set; }
        [Required]
        public int BoardId { get; set; }


        public Hanging Hanging { get; set; }
        public Board Board { get; set; }
    }

    [Table("SMDItem", Schema = "store")]
    public class SMDItemMap
    {
        [Key]
        public int SMDItemId { get; set; }
        [Required]
        public string NameItem { get; set; }
        [Required]
        public int BoardId { get; set; }
        [Required]
        public int SmdId { get; set; }


        public SMD Smd { get; set; }
        public Board Board { get; set; }
    }
}
