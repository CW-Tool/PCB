using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.Warehouse
{
    /// <summary>
    /// kOm, MOm, pkF and etc
    /// </summary>
    [Table("RatedItem", Schema = "store")]
    public class RatedItem
    {
        [Key]
        public int RatedItemId { get; set; }
        [Required]
        public string NomValue { get; set; }

        public virtual ICollection<Hanging> Hangings { get; set; }
        public virtual ICollection<SMD> SMDs { get; set; }
    }
}
