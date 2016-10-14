using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Map
{
    [Table("MapBoard", Schema = "plan")]
    public class MapBoard
    {
        [Key]
        public int SingleMapBoardId { get; set; }
        [Required]
        public int CountBoard { get; set; }
        [Required]
        public int CountHanging { get; set; }
        [Required]
        public int CountDvc { get; set; }
        [Required]
        public int CountEbso { get; set; }
        [Required]
        public int CountPreComplete { get; set; }
        [Required]
        public int CountReadyDone { get; set; }


        [Required]
        public int BoardId { get; set; }
        [Required]
        public int MapId { get; set; }


        public Board Board { get; set; }
        public Map Map { get; set; }
    }
}
