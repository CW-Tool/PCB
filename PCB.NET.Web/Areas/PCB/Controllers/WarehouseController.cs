using PCB.NET.Domain.Abstract.PCB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCB.NET.Web.Areas.PCB.Controllers
{
    public class WarehouseController : DefaultController
    {
        public WarehouseController(IRepositoryPCBwarehouse repositoryWarehouse)
        {
            _repositoryPCBwarehouse = repositoryWarehouse;
        }
        public ActionResult Index()
        {
            var model = _repositoryPCBwarehouse.SMD.OrderBy(m => m.SMDId).ToList();
            return View(model);
        }
    }
}