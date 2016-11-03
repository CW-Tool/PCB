using AutoMapper;
using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Model.WorkshopPCB.Employee;
using PCB.NET.Web.Areas.PCB.Models.EmployeeViewModel;
using PCB.NET.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PCB.NET.Web.Areas.PCB.Controllers
{
    public class EmployeeController : DefaultController
    {
        public int PageSize = 20;
        public EmployeeController(IRepositoryPCBemployee repositoryPCBemployee,
            IRepositoryPCBwarehouse repositoryPCBwarehouse)
        {
            _repositoryPCBemployee = repositoryPCBemployee;
            _repositoryPCBwarehouse = repositoryPCBwarehouse;

        }

        public ActionResult Index()
        {
            return View();
        }

        #region Employee
        public ActionResult EmployeeList(int page = 1)
        {
            EmployeeListViewModel model = new EmployeeListViewModel
            {
                Employee = _repositoryPCBemployee.Employee
                    .Include(e => e.Position)
                    .OrderBy(m => m.Id)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                ListView = new ListView
                {
                    EntitiesPerPages = PageSize,
                    CurrentPage = page,
                    TotalEntities = _repositoryPCBemployee.Employee.Count()

                }
            };

            return View(model);
        }

        public async Task<ActionResult> Details_Employee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBemployee.Employee.FirstOrDefaultAsync(m => m.Id == id);

            IMapper map = MappingConfig.MapperConfigEmployee.CreateMapper();
            EmployeeViewModel context = map.Map<EmployeeViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        public ActionResult Create_Employee()
        {
            ViewBag.PositionId = new SelectList(_repositoryPCBemployee.Position, "Id", "PositionEmp");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_Employee([Bind(Include = "Id,FirstName,MidName,LastName,DescriptionWorker,PositionId")] EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigEmployee.CreateMapper();
                    Employee context = map.Map<Employee>(model);

                    await _repositoryPCBemployee.AddEmployeeAsync(context);

                    ModelState.Clear();
                    return RedirectToAction("EmployeeList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    ModelState.Clear();
                }
            }
            ViewBag.PositionId = new SelectList(_repositoryPCBemployee.Position, "Id", "PositionEmp", model.PositionId);
            return View(model);
        }

        public async Task<ActionResult> Edit_Employee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBemployee.Employee.FirstOrDefaultAsync(m => m.Id == id);

            IMapper map = MappingConfig.MapperConfigEmployee.CreateMapper();
            EmployeeViewModel context = map.Map<EmployeeViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            ViewBag.PositionId = new SelectList(_repositoryPCBemployee.Position, "Id", "PositionEmp", model.PositionId);
            return View(context);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_Employee([Bind(Include = "Id,FirstName,MidName,LastName,DescriptionWorker,PositionId")] EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigEmployee.CreateMapper();
                    Employee context = map.Map<Employee>(model);

                    await _repositoryPCBemployee.EditEmployeeAsync(context);

                    return RedirectToAction("EmployeeList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            ViewBag.PositionId = new SelectList(_repositoryPCBemployee.Position, "Id", "PositionEmp", model.PositionId);
            return View(model);
        }


        public async Task<ActionResult> Delete_Employee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBemployee.Employee.FirstOrDefaultAsync(m => m.Id == id);

            IMapper map = MappingConfig.MapperConfigEmployee.CreateMapper();
            EmployeeViewModel context = map.Map<EmployeeViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }

            return View(context);
        }


        [HttpPost, ActionName("Delete_Employee")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedEmployee(int id)
        {
            try
            {
                var context = await _repositoryPCBemployee.Employee.FirstOrDefaultAsync(m => m.Id == id);
                await _repositoryPCBemployee.DeleteEmployeeAsync(context);

                return RedirectToAction("EmployeeList");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return RedirectToAction("Delete_Employee", id);
        }
        #endregion

        #region DoneWork
        public ActionResult DoneWorkList(int page = 1)
        {
            DoneWorkListViewModel model = new DoneWorkListViewModel
            {
                DoneWork = _repositoryPCBemployee.DoneWork
                    .Include(d => d.Board)
                    .Include(d => d.Employee)
                    .OrderBy(m => m.DoneId)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                ListView = new ListView
                {
                    EntitiesPerPages = PageSize,
                    CurrentPage = page,
                    TotalEntities = _repositoryPCBemployee.DoneWork.Count()

                }
            };

            return View(model);
        }

        public async Task<ActionResult> Details_DoneWork(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBemployee.DoneWork.FirstOrDefaultAsync(m => m.DoneId == id);

            IMapper map = MappingConfig.MapperConfigDoneWork.CreateMapper();
            DoneWorkViewModel context = map.Map<DoneWorkViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        public ActionResult Create_DoneWork()
        {
            ViewBag.BoardId = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock");
            ViewBag.EmployeeId = new SelectList(_repositoryPCBemployee.Employee, "Id", "FirstName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_DoneWork([Bind(Include = "DoneId,Count,DateTime,Description,EmployeeId,BoardId")] DoneWorkViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigDoneWork.CreateMapper();
                    DoneWork context = map.Map<DoneWork>(model);

                    await _repositoryPCBemployee.AddDoneWorkAsync(context);

                    ModelState.Clear();
                    return RedirectToAction("DoneWorkList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    ModelState.Clear();
                }
            }
            ViewBag.BoardId = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock", model.BoardId);
            ViewBag.EmployeeId = new SelectList(_repositoryPCBemployee.Employee, "Id", "FirstName", model.EmployeeId);
            return View(model);
        }

        public async Task<ActionResult> Edit_DoneWork(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBemployee.DoneWork.FirstOrDefaultAsync(m => m.DoneId == id);

            IMapper map = MappingConfig.MapperConfigDoneWork.CreateMapper();
            DoneWorkViewModel context = map.Map<DoneWorkViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoardId = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock", model.BoardId);
            ViewBag.EmployeeId = new SelectList(_repositoryPCBemployee.Employee, "Id", "FirstName", model.EmployeeId);
            return View(context);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_DoneWork([Bind(Include = "DoneId,Count,DateTime,Description,EmployeeId,BoardId")] DoneWorkViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigDoneWork.CreateMapper();
                    DoneWork context = map.Map<DoneWork>(model);

                    await _repositoryPCBemployee.EditDoneWorkAsync(context);

                    return RedirectToAction("DoneWorkList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            ViewBag.BoardId = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock", model.BoardId);
            ViewBag.EmployeeId = new SelectList(_repositoryPCBemployee.Employee, "Id", "FirstName", model.EmployeeId);
            return View(model);
        }


        public async Task<ActionResult> Delete_DoneWork(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBemployee.DoneWork.FirstOrDefaultAsync(m => m.DoneId == id);

            IMapper map = MappingConfig.MapperConfigDoneWork.CreateMapper();
            DoneWorkViewModel context = map.Map<DoneWorkViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }

            return View(context);
        }


        [HttpPost, ActionName("Delete_Employee")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedDoneWork(int id)
        {
            try
            {
                var context = await _repositoryPCBemployee.DoneWork.FirstOrDefaultAsync(m => m.DoneId == id);
                await _repositoryPCBemployee.DeleteDoneWorkAsync(context);

                return RedirectToAction("DoneWorkList");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return RedirectToAction("Delete_DoneWork", id);
        }
        #endregion

        #region Position
        public ActionResult PositionList(int page = 1)
        {
            PositionListViewModel model = new PositionListViewModel
            {
                Position = _repositoryPCBemployee.Position
                    .OrderBy(m => m.Id)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                ListView = new ListView
                {
                    EntitiesPerPages = PageSize,
                    CurrentPage = page,
                    TotalEntities = _repositoryPCBemployee.Position.Count()

                }
            };

            return View(model);
        }

        public async Task<ActionResult> Details_Position(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBemployee.Position.FirstOrDefaultAsync(m => m.Id == id);

            IMapper map = MappingConfig.MapperConfigPosition.CreateMapper();
            PositionViewModel context = map.Map<PositionViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        public ActionResult Create_Position()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_Position([Bind(Include = "Id,PositionEmp")] PositionViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigPosition.CreateMapper();
                    Position context = map.Map<Position>(model);

                    await _repositoryPCBemployee.AddPositionAsync(context);

                    ModelState.Clear();
                    return RedirectToAction("PositionList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    ModelState.Clear();
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Edit_Position(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBemployee.Position.FirstOrDefaultAsync(m => m.Id == id);

            IMapper map = MappingConfig.MapperConfigPosition.CreateMapper();
            PositionViewModel context = map.Map<PositionViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_Position([Bind(Include = "Id,PositionEmp")] PositionViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigPosition.CreateMapper();
                    Position context = map.Map<Position>(model);

                    await _repositoryPCBemployee.EditPositionAsync(context);

                    return RedirectToAction("PositionList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            return View(model);
        }


        public async Task<ActionResult> Delete_Position(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBemployee.Position.FirstOrDefaultAsync(m => m.Id == id);

            IMapper map = MappingConfig.MapperConfigPosition.CreateMapper();
            PositionViewModel context = map.Map<PositionViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }

            return View(context);
        }


        [HttpPost, ActionName("Delete_Position")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedPosition(int id)
        {
            try
            {
                var context = await _repositoryPCBemployee.Position.FirstOrDefaultAsync(m => m.Id == id);
                await _repositoryPCBemployee.DeletePositionAsync(context);

                return RedirectToAction("PositionList");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return RedirectToAction("Delete_Position", id);
        }
        #endregion

    }
}