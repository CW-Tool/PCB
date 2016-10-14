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


        [Required]
        [ForeignKey("SMD")]
        public int SMDId { get; set; }
        [Required]
        [ForeignKey("Hanging")]
        public int HangingId { get; set; }


        public virtual SMD SMD { get; set; }
        public virtual Hanging Hanging { get; set; }
    }

    [Table("HangingItem", Schema = "store")]
    public class HangingItemMap
    {
        [Key]
        public int HangingItemId { get; set; }
        [Required]
        public int HangingId { get; set; }
        [Required]
        public int BoardId { get; set; }


        public virtual Hanging Hanging { get; set; }
        public virtual Board Board { get; set; }
    }

    [Table("SMDItem", Schema = "store")]
    public class SMDItemMap
    {
        [Key]
        public int SMDItemId { get; set; }
        [Required]
        public int BoardId { get; set; }
        [Required]
        public int SmdId { get; set; }


        public virtual SMD Smd { get; set; }
        public virtual Board Board { get; set; }
    }
}
