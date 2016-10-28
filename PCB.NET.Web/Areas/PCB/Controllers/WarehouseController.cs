using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Model;
using System;
using System.Linq;
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
            ModelContext db = new ModelContext();
            var model = db.SMDs.OrderBy(m => m.SMDId).ToList();
            //var model = _repositoryPCBwarehouse.SMD.OrderBy(m => m.ItemId).ToList();

            int q = 2;
            int w = 1;
            var e = q - w;

            return View(model);
        }
        public ActionResult BadAction()
        {
            throw new Exception("You forgot to implement this ACTION!");
        }
    }
}