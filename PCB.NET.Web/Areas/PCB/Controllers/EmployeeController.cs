using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Web.Areas.PCB.Models.EmployeeViewModel;
using PCB.NET.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCB.NET.Web.Areas.PCB.Controllers
{
    public class EmployeeController : DefaultController
    {
        public int PageSize = 20;
        public EmployeeController(IRepositoryPCBemployee repositoryPCBemployee)
        {
            _repositoryPCBemployee = repositoryPCBemployee;
        }

        public ActionResult Index(int page = 1)
        {
            EmployeeListViewModel model = new EmployeeListViewModel
            {
                Employee = _repositoryPCBemployee.Employee
                .OrderBy(m => m.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                ListView = new ListView
                {
                    CurrentPage = page,
                    EntitiesPerPages = PageSize,
                    TotalEntities = _repositoryPCBemployee.Employee.Count()
                }
            };
            return View(model);
        }
    }
}