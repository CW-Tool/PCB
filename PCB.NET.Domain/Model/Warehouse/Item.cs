using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB.NET.Domain.Model.Warehouse
{
    [Table("Item", Schema="store")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string NameItem { get; set; }
    }
}
