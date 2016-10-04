using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.Warehouse.WorkshopPCB
{
    /// <summary>
    /// Size SMD
    /// </summary>
    [Table("Size", Schema = "store")]
    public class Size
    {
        [Key]
        public int SizeId { get; set; }
        [Required]
        public int SizeItem { get; set; }

        public virtual ICollection<Hanging> Hangings { get; set; }
        public virtual ICollection<SMD> SMDs { get; set; }
    }
}
