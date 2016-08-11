using PCB.NET.Domain.Model.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB.NET.Domain.Model.Employee
{
    [Table("DoneWork", Schema = "employee")]
    public class DoneWork
    {
        [Key]
        public int DoneId { get; set; }
        [Required]
        public Board Board { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
