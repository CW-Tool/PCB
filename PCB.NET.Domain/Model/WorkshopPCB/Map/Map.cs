using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Map
{
    [Table("Map", Schema = "plan")]
    public class Map
    {
        [Key]
        public int MapId { get; set; }
        [Required]
        public Month Date { get; set; }
        public DateTime Modified { get; set; }


        public virtual ICollection<MapBoard> MapBoard { get; set; }
    }

    public enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}
