using PCB.NET.Domain.Model.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB.NET.Domain.Model.Machine
{
    [Table("Systronic", Schema = "machine")]
    public class Systronic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Board Board { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public string Description { get; set; }

        public DateTime? LastUpdate { get; set; }
    }
}
