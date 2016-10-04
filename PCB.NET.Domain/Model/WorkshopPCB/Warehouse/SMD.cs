using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.Warehouse.WorkshopPCB
{
    /// <summary>
    /// SMD elements
    /// </summary>
    [Table("SMD", Schema = "store")]
    public class SMD
    {
        public SMD()
        {
            BoardSMD = new HashSet<Board>();

        }
        [Key]
        public int SMDId { get; set; }
        [Required]
        public virtual Item Item { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public virtual RatedItem RatedItem { get; set; }
        [Required]
        public string DescriptionItem { get; set; }
        [Required]
        public virtual Size Size { get; set; }
        [Required]
        public string Packages { get; set; }
        [Required]
        public int Feeder { get; set; }
        [Required]
        public int CountItem { get; set; }
        public DateTime? LastUpdate { get; set; }

        public virtual ICollection<Board> BoardSMD { get; set; }
    }
}
