using PCB.NET.Domain.Abstract.PCB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCB.NET.Web.Areas.PCB.Controllers
{
    [Authorize]
    public class HomeController : DefaultController
    {
        public HomeController(IRepositoryPCBmachine repositoryMachine)
        {
            _repositoryPCBmachine = repositoryMachine;
        }

        public ActionResult Index()
        {

            return View();
        }
    }
}