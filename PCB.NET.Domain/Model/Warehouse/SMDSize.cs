using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB.NET.Domain.Model.Warehouse
{
    [Table("Size", Schema = "store")]
    public class SMDSize
    {
        [Key]
        public int SizeId { get; set; }
        [Required]
        public int Size { get; set; }
    }
}
