using AutoMapper;
using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Model.WorkshopPCB.Map;
using PCB.NET.Web.Areas.PCB.Models.MapViewModel;
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
    public class MapController : DefaultController
    {
        private readonly int PageSize = 20;
        public MapController(IRepositoryPCBmap repositoryPCBmap,
            IRepositoryPCBwarehouse repositoryPCBwarehouse)
        {
            _repositoryPCBmap = repositoryPCBmap;
            _repositoryPCBwarehouse = repositoryPCBwarehouse;
        }
        public ActionResult Index(int page = 1)
        {
            MapListViewModel model = new MapListViewModel
            {
                Map = _repositoryPCBmap.Map
        .OrderBy(m => m.MapId)
        .AsEnumerable()
        .Reverse()
        .Skip((page - 1) * PageSize)
        .Take(PageSize),

                ListView = new ListView
                {
                    EntitiesPerPages = PageSize,
                    CurrentPage = page,
                    TotalEntities = _repositoryPCBmap.Map.Count()

                }
            };

            return View(model);
        }

        #region Map
        //public ActionResult MapList(int page = 1)
        //{
        //    MapListViewModel model = new MapListViewModel
        //    {
        //        Map = _repositoryPCBmap.Map
        //            .OrderBy(m => m.MapId)
        //            .AsEnumerable()
        //            .Reverse()
        //            .Skip((page - 1) * PageSize)
        //            .Take(PageSize),

        //        ListView = new ListView
        //        {
        //            EntitiesPerPages = PageSize,
        //            CurrentPage = page,
        //            TotalEntities = _repositoryPCBmap.Map.Count()

        //        }
        //    };

        //    return View(model);
        //}

        public async Task<ActionResult> Details_Map(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBmap.Map.FirstOrDefaultAsync(m => m.MapId == id);

            IMapper map = MappingConfig.MapperConfigMap.CreateMapper();
            MapViewModel context = map.Map<MapViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        public ActionResult Create_Map()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_Map([Bind(Include = "MapId,Date,Modified")] MapViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigMap.CreateMapper();
                    Map context = map.Map<Map>(model);

                    await _repositoryPCBmap.AddMapAsync(context);

                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    ModelState.Clear();
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Edit_Map(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBmap.Map.FirstOrDefaultAsync(m => m.MapId == id);

            IMapper map = MappingConfig.MapperConfigMap.CreateMapper();
            MapViewModel context = map.Map<MapViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_Map([Bind(Include = "MapId,Date,Modified")] MapViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigMap.CreateMapper();
                    Map context = map.Map<Map>(model);

                    await _repositoryPCBmap.EditMapAsync(context);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            return View(model);
        }


        public async Task<ActionResult> Delete_Map(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBmap.Map.FirstOrDefaultAsync(m => m.MapId == id);

            IMapper map = MappingConfig.MapperConfigMap.CreateMapper();
            MapViewModel context = map.Map<MapViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }

            return View(context);
        }


        [HttpPost, ActionName("Delete_Map")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedMap(int id)
        {
            try
            {
                var context = await _repositoryPCBmap.Map.FirstOrDefaultAsync(m => m.MapId == id);
                await _repositoryPCBmap.DeleteMapAsync(context);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return RedirectToAction("Delete_Map", id);
        }

        //public async Task<ActionResult> Modified(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var model = await _repositoryPCBmap.MapBoard.FirstOrDefaultAsync(m => m.SingleMapBoardId == id);

        //    IMapper map = MappingConfig.MapperConfigMapBoard.CreateMapper();
        //    MapBoardViewModel context = map.Map<MapBoardViewModel>(model);

        //    if (context == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.BoardId = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock", model.BoardId);
        //    ViewBag.MapId = new SelectList(_repositoryPCBmap.Map, "MapId", "MapId", model.MapId);

        //    return View("Edit_MapBoard", context);
        //}
        #endregion

        #region MapBoard
        public ActionResult MapBoardList(int page = 1, int map = 0)
        {
            MapBoardListViewModel model = new MapBoardListViewModel
            {
                MapBoard = _repositoryPCBmap.MapBoard
                    .Include(m => m.Board)
                    .Include(m => m.Map)
                    .OrderBy(m => m.SingleMapBoardId)
                    .Where(m => m.MapId == map)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                ListView = new ListView
                {
                    EntitiesPerPages = PageSize,
                    CurrentPage = page,
                    TotalEntities = _repositoryPCBmap.MapBoard.Count()
                },

                CurrentMap = map
            };

            return View(model);
        }

        public async Task<ActionResult> Details_MapBoard(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBmap.MapBoard.FirstOrDefaultAsync(m => m.SingleMapBoardId == id);

            IMapper map = MappingConfig.MapperConfigMapBoard.CreateMapper();
            MapBoardViewModel context = map.Map<MapBoardViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        public ActionResult Create_MapBoard(int? id)
        {
            ViewBag.BoardId = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock");

            if (id == null)
            {
                ViewBag.CurrentMap = 1;
                ViewBag.MapId = new SelectList(_repositoryPCBmap.Map, "MapId", "MapId");
                return View();
            }

            ViewBag.MapId = new SelectList(_repositoryPCBmap.Map, "MapId", "MapId", id);
            ViewBag.CurrentMap = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_MapBoard([Bind(Include = "SingleMapBoardId,CountBoard,CountHanging,CountDvc,CountEbso,CountPreComplete,CountReadyDone,BoardId,MapId")] MapBoardViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigMapBoard.CreateMapper();
                    MapBoard context = map.Map<MapBoard>(model);

                    await _repositoryPCBmap.AddMapBoardAsync(context);

                    ModelState.Clear();
                    return RedirectToAction("MapBoardList", "Map", new { id = 1, map = model.MapId});
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    ModelState.Clear();
                }
            }
            ViewBag.BoardId = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock", model.BoardId);
            ViewBag.MapId = new SelectList(_repositoryPCBmap.Map, "MapId", "MapId", model.MapId);
            return View(model);
        }

        public async Task<ActionResult> Edit_MapBoard(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBmap.MapBoard.FirstOrDefaultAsync(m => m.SingleMapBoardId == id);

            IMapper map = MappingConfig.MapperConfigMapBoard.CreateMapper();
            MapBoardViewModel context = map.Map<MapBoardViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoardId = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock", model.BoardId);
            ViewBag.MapId = new SelectList(_repositoryPCBmap.Map, "MapId", "MapId", model.MapId);
            return View(context);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_MapBoard([Bind(Include = "SingleMapBoardId,CountBoard,CountHanging,CountDvc,CountEbso,CountPreComplete,CountReadyDone,BoardId,MapId")] MapBoardViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigMapBoard.CreateMapper();
                    MapBoard context = map.Map<MapBoard>(model);

                    await _repositoryPCBmap.EditMapBoardAsync(context);

                    return RedirectToAction("MapBoardList", "Map", new { id = 1, map = model.MapId });
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            ViewBag.BoardId = new SelectList(_repositoryPCBwarehouse.Board, "BoardId", "NameBlock", model.BoardId);
            ViewBag.MapId = new SelectList(_repositoryPCBmap.Map, "MapId", "MapId", model.MapId);
            return View(model);
        }


        public async Task<ActionResult> Delete_MapBoard(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBmap.MapBoard.FirstOrDefaultAsync(m => m.SingleMapBoardId == id);

            IMapper map = MappingConfig.MapperConfigMapBoard.CreateMapper();
            MapBoardViewModel context = map.Map<MapBoardViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }

            return View(context);
        }


        [HttpPost, ActionName("Delete_MapBoard")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedMapBoard(int id)
        {
            try
            {
                var context = await _repositoryPCBmap.MapBoard.FirstOrDefaultAsync(m => m.SingleMapBoardId == id);
                await _repositoryPCBmap.DeleteMapBoardAsync(context);

                return RedirectToAction("MapBoardList", "Map", new { id = 1, map = context.MapId });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return RedirectToAction("Delete_MapBoard", id);
        }
        #endregion
    }
}