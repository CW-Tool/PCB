using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
