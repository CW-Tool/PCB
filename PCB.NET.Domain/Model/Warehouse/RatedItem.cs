using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.Warehouse
{
    [Table("Rated", Schema = "store")]
    public class RatedItem
    {
        [Key]
        public int RatedId { get; set; }
        [Required]
        public string NomValue { get; set; }
    }
}
