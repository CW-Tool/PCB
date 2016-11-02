using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel
{
    public class SizeListViewModel
    {
        public IEnumerable<Size> Size { get; set; }
        public ListView ListView { get; set; }
    }

    public class SizeViewModel
    {
        public int SizeId { get; set; }
        [Required]
        public string Sizes { get; set; }
        public virtual ICollection<Hanging> Hanging { get; set; }
    }
}
