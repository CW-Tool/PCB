using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Warehouse
{
    /// <summary>
    /// Size 5mm, 15mm
    /// </summary>
    [Table("Size", Schema = "store")]
    public class Size
    {
        [Key]
        public int SizeId { get; set; }
        [Required]
        public string Sizes { get; set; }
        public virtual ICollection<Hanging> Hanging { get; set; }

    }

    /// <summary>
    /// Size SMD, 1206, 2010, 0603...
    /// </summary>
    [Table("Packages", Schema = "store")]
    public class Package
    {
        [Key]
        public int PackagesId { get; set; }
        [Required]
        public string Packs { get; set; }
        public virtual ICollection<SMD> SMD { get; set; }
    }
}
