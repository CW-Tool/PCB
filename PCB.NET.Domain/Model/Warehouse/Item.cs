using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
