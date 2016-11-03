using PCB.NET.Domain.Model.WorkshopPCB.Map;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCB.NET.Web.Areas.PCB.Models.MapViewModel
{
    public class MapBoardListViewModel
    {
        public IEnumerable<MapBoard> MapBoard { get; set; }
        public ListView ListView { get; set; }
    }

    public class MapBoardViewModel
    {
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


        public virtual Board Board { get; set; }
        public virtual Map Map { get; set; }
    }
}