using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Model;
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
            //ModelContext db = new ModelContext();
            //var model = db.SMDs.OrderBy(m => m.SMDId).ToList();

            //int q = 2;
            //int w = 1;
            //var e = q - w;

            return View();
        }
    }
}