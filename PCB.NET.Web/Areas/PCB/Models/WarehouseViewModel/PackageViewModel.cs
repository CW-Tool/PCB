using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel
{
    public class PackageListViewModel
    {
        public IEnumerable<Package> Package { get; set; }
        public ListView ListView { get; set; }
    }

    public class PackageViewModel
    {
        public int PackagesId { get; set; }
        [Required]
        public string Packs { get; set; }
        public virtual ICollection<SMD> SMD { get; set; }
    }
}