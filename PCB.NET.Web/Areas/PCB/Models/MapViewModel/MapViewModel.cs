using PCB.NET.Domain.Model.WorkshopPCB.Map;
using PCB.NET.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCB.NET.Web.Areas.PCB.Models.MapViewModel
{
    public class MapListViewModel
    {
        public IEnumerable<MapViewModel> Map { get; set; }
        public ListView ListView { get; set; }
        public Month Date { get; set; }
    }

    public class MapViewModel
    {
        public int MapId { get; set; }
        [Required]
        [Display(Name = "Дата")]
        public Month Date { get; set; }
        [Display(Name = "Последние изменения")]
        public DateTime Modified { get; set; }


        public virtual ICollection<MapBoard> MapBoard { get; set; }
    }
}