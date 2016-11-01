using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel
{
    public class GasBalloonListViewModel
    {
        public IEnumerable<GasBalloon> GasBalloon { get; set; }
        public ListView ListView { get; set; }
    }

    public class GasBalloonViewModel
    {
        [HiddenInput]
        public int GasBalloonId { get; set; }
        [Required]
        public string BalloonNumber { get; set; }
        [Required]
        public string DateNextModified { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
    }
}