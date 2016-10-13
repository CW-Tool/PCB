using PCB.NET.Domain.Model.WorkshopPCB.Employee;
using PCB.NET.Domain.Model.WorkshopPCB.Machine;
using PCB.NET.Domain.Model.WorkshopPCB.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Warehouse
{
    /// <summary>
    /// Board
    /// </summary>
    [Table("Board", Schema = "store")]
    public class Board
    {
        [Key]
        public int BoardId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CountBoard { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        public Ebso Ebso { get; set; }
        public Dvc Dvc { get; set; }

        public virtual ICollection<MapBoard> MapBoard { get; set; }
        public virtual ICollection<DoneWork> DoneWork { get; set; }
        public virtual ICollection<HangingItem> HangingItems { get; set; }
        public virtual ICollection<SMDItem> SMDItems { get; set; }
    }
}
