using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Warehouse
{
    public enum Item
    {
        Capacitor,
        Diod,
        Varistor
    }

    [Table("HangingItem", Schema = "store")]
    public class HangingItem
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
    public class SMDItem
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
