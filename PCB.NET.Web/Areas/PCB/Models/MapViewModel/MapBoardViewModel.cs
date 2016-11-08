using PCB.NET.Domain.Model.WorkshopPCB.Map;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCB.NET.Web.Areas.PCB.Models.MapViewModel
{
    public class MapBoardListViewModel
    {
        public IEnumerable<MapBoardViewModel> MapBoard { get; set; }
        public ListView ListView { get; set; }
        public int CurrentMap { get; set; }
        public MapBoardViewModel MapBoardSingle { get; set; }
    }

    public class MapBoardViewModel
    {
        public int SingleMapBoardId { get; set; }
        [Required]
        [Display(Name = "Количество")]
        public int CountBoard { get; set; }
        [Required]
        [Display(Name = "Навесные элементы")]
        public int CountHanging { get; set; }
        [Required]
        [Display(Name = "SMD - компоненты")]
        public int CountDvc { get; set; }
        [Required]
        [Display(Name = "Селективная пайка")]
        public int CountEbso { get; set; }
        [Required]
        [Display(Name = "Предъявлено ОТК")]
        public int CountPreComplete { get; set; }
        [Required]
        [Display(Name = "Годные")]
        public int CountReadyDone { get; set; }


        [Required]
        [Display(Name = "Плата")]
        public int BoardId { get; set; }
        [Required]
        [Display(Name = "План")]
        public int MapId { get; set; }


        public virtual Board Board { get; set; }
        public virtual Map Map { get; set; }
    }
}