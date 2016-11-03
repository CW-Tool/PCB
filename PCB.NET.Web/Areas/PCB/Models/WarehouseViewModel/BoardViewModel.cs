using PCB.NET.Domain.Model.WorkshopPCB.Employee;
using PCB.NET.Domain.Model.WorkshopPCB.Machine;
using PCB.NET.Domain.Model.WorkshopPCB.Map;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel
{
    public class BoardListViewModel
    {
        public IEnumerable<Board> Board { get; set; }
        public ListView ListView { get; set; }
    }

    public class BoardViewModel
    {
        public int BoardId { get; set; }
        [Required]
        public string NameBlock { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public int CountBoard { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }

        public virtual Ebso Ebso { get; set; }
        public virtual Dvc Dvc { get; set; }

        public virtual ICollection<MapBoard> MapBoard { get; set; }
        public virtual ICollection<DoneWork> DoneWork { get; set; }
        public virtual ICollection<HangingItemMap> HangingItemMap { get; set; }
        public virtual ICollection<SMDItemMap> SMDItemMap { get; set; }
    }
}