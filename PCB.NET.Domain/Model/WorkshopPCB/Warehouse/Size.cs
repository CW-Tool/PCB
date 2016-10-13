using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Warehouse
{
    /// <summary>
    /// Size SMD, 1206, 2010, 0603...
    /// </summary>
    [Table("Size", Schema = "store")]
    public class Size
    {
        [Key]
        [ForeignKey("Hanging")]
        public int SizeId { get; set; }
        [Required]
        public string Sizes { get; set; }
        [Required]
        public Hanging Hanging { get; set; }

    }

    [Table("Packages", Schema = "store")]
    public class Package
    {
        [Key]
        [ForeignKey("SMD")]
        public int PackagesId { get; set; }
        [Required]
        public string Packs { get; set; }
        [Required]
        public SMD SMD { get; set; }
    }
}
