using AutoMapper;
using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Model.WorkshopPCB.Machine;
using PCB.NET.Web.Areas.PCB.Models.MachineViewModel;
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
    public class MachineController : DefaultController
    {
        private readonly int PageSize = 20;
        public MachineController(IRepositoryPCBmachine repositoryPCBmachine,
            IRepositoryPCBwarehouse repositoryPCBwarehouse)
        {
            _repositoryPCBmachine = repositoryPCBmachine;
            _repositoryPCBwarehouse = repositoryPCBwarehouse;
        }
        // GET: PCB/Machine
        public ActionResult Index()
        {
            return View();
        }

        #region EBSO
        public ActionResult EbsoList(int page = 1)
        {
            EbsoListViewModel model = new EbsoListViewModel
            {
                Ebso = _repositoryPCBmachine.Ebso
                    .Include(e => e.Board)  
                    .OrderBy(m => m.Id)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                ListView = new ListView
                {
                    EntitiesPerPages = PageSize,
                    CurrentPage = page,
                    TotalEntities = _repositoryPCBmachine.Ebso.Count()

                }
            };

            return View(model);
        }

        public async Task<ActionResult> Details_Ebso(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBmachine.Ebso.FirstOrDefaultAsync(m => m.Id == id);

            IMapper map = MappingConfig.MapperConfigEbso.CreateMapper();
            EbsoViewModel context = map.Map<EbsoViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        public ActionResult Create_Ebso()
        {
            ViewBag.Id = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_Ebso([Bind(Include = "Id,TimeSecond,Description")] EbsoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigEbso.CreateMapper();
                    Ebso context = map.Map<Ebso>(model);

                    await _repositoryPCBmachine.AddEbsoAsync(context);

                    ModelState.Clear();
                    return RedirectToAction("EbsoList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    ModelState.Clear();
                }
                ViewBag.Id = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock", model.Id);
            }
            return View(model);
        }

        public async Task<ActionResult> Edit_Ebso(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBmachine.Ebso.FirstOrDefaultAsync(m => m.Id == id);

            IMapper map = MappingConfig.MapperConfigEbso.CreateMapper();
            EbsoViewModel context = map.Map<EbsoViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock", model.Id);
            return View(context);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_Ebso([Bind(Include = "Id,TimeSecond,Description")] EbsoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigEbso.CreateMapper();
                    Ebso context = map.Map<Ebso>(model);

                    await _repositoryPCBmachine.EditEbsoAsync(context);

                    return RedirectToAction("EbsoList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            ViewBag.Id = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock", model.Id);
            return View(model);
        }


        public async Task<ActionResult> Delete_Ebso(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBmachine.Ebso.FirstOrDefaultAsync(m => m.Id == id);

            IMapper map = MappingConfig.MapperConfigEbso.CreateMapper();
            EbsoViewModel context = map.Map<EbsoViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }

            return View(context);
        }


        [HttpPost, ActionName("Delete_Ebso")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedEbso(int id)
        {
            try
            {
                var context = await _repositoryPCBmachine.Ebso.FirstOrDefaultAsync(m => m.Id == id);
                await _repositoryPCBmachine.DeleteEbsoAsync(context);

                return RedirectToAction("EbsoList");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return RedirectToAction("Delete_Ebso", id);
        }
        #endregion

        #region DVC
        public ActionResult DvcList(int page = 1)
        {
            DvcListViewModel model = new DvcListViewModel
            {
                Dvc = _repositoryPCBmachine.Dvc
                    .Include(e => e.Board)
                    .OrderBy(m => m.Id)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                ListView = new ListView
                {
                    EntitiesPerPages = PageSize,
                    CurrentPage = page,
                    TotalEntities = _repositoryPCBmachine.Dvc.Count()

                }
            };

            return View(model);
        }

        public async Task<ActionResult> Details_Dvc(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBmachine.Dvc.FirstOrDefaultAsync(m => m.Id == id);

            IMapper map = MappingConfig.MapperConfigDvc.CreateMapper();
            DvcViewModel context = map.Map<DvcViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        public ActionResult Create_Dvc()
        {
            ViewBag.Id = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_Dvc([Bind(Include = "Id,TimeSecond,Description")] DvcViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigDvc.CreateMapper();
                    Dvc context = map.Map<Dvc>(model);

                    await _repositoryPCBmachine.AddDvcAsync(context);

                    ModelState.Clear();
                    return RedirectToAction("DvcList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    ModelState.Clear();
                }
                ViewBag.Id = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock", model.Id);
            }
            return View(model);
        }

        public async Task<ActionResult> Edit_Dvc(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBmachine.Dvc.FirstOrDefaultAsync(m => m.Id == id);

            IMapper map = MappingConfig.MapperConfigDvc.CreateMapper();
            DvcViewModel context = map.Map<DvcViewModel> (model);

            if (context == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock", model.Id);
            return View(context);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_Dvc([Bind(Include = "Id,TimeSecond,Description")] DvcViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigDvc.CreateMapper();
                    Dvc context = map.Map<Dvc>(model);

                    await _repositoryPCBmachine.EditDvcAsync(context);

                    return RedirectToAction("DvcList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            ViewBag.Id = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock", model.Id);
            return View(model);
        }


        public async Task<ActionResult> Delete_Dvc(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBmachine.Dvc.FirstOrDefaultAsync(m => m.Id == id);

            IMapper map = MappingConfig.MapperConfigDvc.CreateMapper();
            DvcViewModel context = map.Map<DvcViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }

            return View(context);
        }


        [HttpPost, ActionName("Delete_Dvc")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedDvc(int id)
        {
            try
            {
                var context = await _repositoryPCBmachine.Dvc.FirstOrDefaultAsync(m => m.Id == id);
                await _repositoryPCBmachine.DeleteDvcAsync(context);

                return RedirectToAction("DvcList");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return RedirectToAction("Delete_Dvc", id);
        }
        #endregion
    }
}