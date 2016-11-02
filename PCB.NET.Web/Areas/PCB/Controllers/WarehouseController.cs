using AutoMapper;
using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel;
using PCB.NET.Web.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PCB.NET.Web.Areas.PCB.Controllers
{
    /// <summary>
    /// Store workshop Printed Circuit Board
    /// </summary>
    /// <seealso cref="PCB.NET.Web.Areas.PCB.Controllers.DefaultController" />
    public class WarehouseController : DefaultController
    {
        private readonly int PageSize = 5;
        /// <summary>
        /// Initializes a new instance of the <see cref="WarehouseController"/> class.
        /// </summary>
        /// <param name="repositoryWarehouse">The repository warehouse.</param>
        public WarehouseController(IRepositoryPCBwarehouse repositoryWarehouse)
        {
            _repositoryPCBwarehouse = repositoryWarehouse;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region CRUD GasBalloon
        /// <summary>
        /// Gases the balloon list.
        /// </summary>
        /// <returns></returns>
        public ActionResult GasBalloonList(int page = 1)
        {
            GasBalloonListViewModel model = new GasBalloonListViewModel
            {
                GasBalloon = _repositoryPCBwarehouse.GasBalloon
                    .OrderBy(m => m.GasBalloonId)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                ListView = new ListView
                {
                    EntitiesPerPages = PageSize,
                    CurrentPage = page,
                    TotalEntities = _repositoryPCBwarehouse.GasBalloon.Count()

                }
            };


            return View(model);
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Details_Balloon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.GasBalloon.FirstOrDefaultAsync(m => m.GasBalloonId == id);

            IMapper map = MappingConfig.MapperConfigGasBalloon.CreateMapper();
            GasBalloonViewModel context = map.Map<GasBalloonViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        /// <summary>
        /// Adds the new balloon.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create_Balloon()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_Balloon(GasBalloonViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.LastUpdate = DateTime.Now;

                    IMapper map = MappingConfig.MapperConfigGasBalloon.CreateMapper();
                    GasBalloon context = map.Map<GasBalloon>(model);

                    await _repositoryPCBwarehouse.AddGasBalloonAsync(context);

                    ModelState.Clear();
                    return RedirectToAction("GasBalloonList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    ModelState.Clear();
                }
            }
            return View(model);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Edit_Balloon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.GasBalloon.FirstOrDefaultAsync(m => m.GasBalloonId == id);

            IMapper map = MappingConfig.MapperConfigGasBalloon.CreateMapper();
            GasBalloonViewModel context = map.Map<GasBalloonViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_Balloon([Bind(Include = "GasBalloonId,BalloonNumber,DateNextModified,LastUpdate")] GasBalloonViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigGasBalloon.CreateMapper();
                    GasBalloon context = map.Map<GasBalloon>(model);

                    await _repositoryPCBwarehouse.EditGasBalloonAsync(context);

                    return RedirectToAction("GasBalloonList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            return View(model);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ActionResult> Delete_Balloon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.GasBalloon.FirstOrDefaultAsync(m => m.GasBalloonId == id);

            IMapper map = MappingConfig.MapperConfigGasBalloon.CreateMapper();
            GasBalloonViewModel context = map.Map<GasBalloonViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete_Balloon")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var context = await _repositoryPCBwarehouse.GasBalloon.FirstOrDefaultAsync(m => m.GasBalloonId == id);
                await _repositoryPCBwarehouse.DeleteGasBalloonAsync(context);

                return RedirectToAction("GasBalloonList");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return RedirectToAction("Delete_Balloon", id);
        }
        #endregion

        #region CRUD Hanging
        public ActionResult HangingList(int page = 1)
        {
            HangingListViewModel model = new HangingListViewModel
            {
                Hanging = _repositoryPCBwarehouse.Hanging
                    .Include(h => h.Item)
                    .Include(h => h.Size)
                    .OrderBy(m => m.HangingId)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                ListView = new ListView
                {
                    EntitiesPerPages = PageSize,
                    CurrentPage = page,
                    TotalEntities = _repositoryPCBwarehouse.Hanging.Count()

                }
            };
            
            return View(model);
        }

        public async Task<ActionResult> Details_Hanging(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.Hanging.FirstOrDefaultAsync(m => m.HangingId == id);

            IMapper map = MappingConfig.MapperConfigHanging.CreateMapper();
            HangingViewModel context = map.Map<HangingViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        public ActionResult Create_Hanging()
        {
            ViewBag.ItemId = new SelectList(_repositoryPCBwarehouse.Item, "ItemId", "NameItem");
            ViewBag.SizeId = new SelectList(_repositoryPCBwarehouse.Size, "SizeId", "Sizes");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_Hanging(HangingViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.LastUpdate = DateTime.Now;

                    IMapper map = MappingConfig.MapperConfigHanging.CreateMapper();
                    Hanging context = map.Map<Hanging>(model);

                    await _repositoryPCBwarehouse.AddHangingAsync(context);

                    ModelState.Clear();
                    return RedirectToAction("HangingList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    ModelState.Clear();
                }
            }
            ViewBag.ItemId = new SelectList(_repositoryPCBwarehouse.Item, "ItemId", "NameItem", model.ItemId);
            ViewBag.SizeId = new SelectList(_repositoryPCBwarehouse.Size, "SizeId", "Sizes", model.SizeId);
            return View(model);
        }

        public async Task<ActionResult> Edit_Hanging(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.Hanging.FirstOrDefaultAsync(m => m.HangingId == id);

            IMapper map = MappingConfig.MapperConfigHanging.CreateMapper();
            HangingViewModel context = map.Map<HangingViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }

            ViewBag.ItemId = new SelectList(_repositoryPCBwarehouse.Item, "ItemId", "NameItem", context.ItemId);
            ViewBag.SizeId = new SelectList(_repositoryPCBwarehouse.Size, "SizeId", "Sizes", context.SizeId);
            return View(context);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_Hanging([Bind(Include = "HangingId,ValueItem,RatedItem,DescriptionItem,CountItem,LastUpdate,ItemId,SizeId")] HangingViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigHanging.CreateMapper();
                    Hanging context = map.Map<Hanging>(model);

                    await _repositoryPCBwarehouse.EditHangingAsync(context);

                    return RedirectToAction("HangingList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            ViewBag.ItemId = new SelectList(_repositoryPCBwarehouse.Item, "ItemId", "NameItem", model.ItemId);
            ViewBag.SizeId = new SelectList(_repositoryPCBwarehouse.Size, "SizeId", "Sizes", model.SizeId);
            return View(model);
        }


        public async Task<ActionResult> Delete_Hanging(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.Hanging.FirstOrDefaultAsync(m => m.HangingId == id);

            IMapper map = MappingConfig.MapperConfigHanging.CreateMapper();
            HangingViewModel context = map.Map<HangingViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }

            ViewBag.ItemId = new SelectList(_repositoryPCBwarehouse.Item, "ItemId", "NameItem", context.ItemId);
            ViewBag.SizeId = new SelectList(_repositoryPCBwarehouse.Size, "SizeId", "Sizes", context.SizeId);
            return View(context);
        }


        [HttpPost, ActionName("Delete_Hanging")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedHanging(int id)
        {
            try
            {
                var context = await _repositoryPCBwarehouse.Hanging.FirstOrDefaultAsync(m => m.HangingId == id);
                await _repositoryPCBwarehouse.DeleteHangingAsync(context);

                return RedirectToAction("HangingList");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return RedirectToAction("Delete_Hanging", id);
        }
        #endregion

        #region CRUD Item

        #endregion

        #region CRUD OtherStore
        public ActionResult OtherStoreList(int page = 1)
        {
            OtherStoreListViewModel model = new OtherStoreListViewModel
            {
                OtherStore = _repositoryPCBwarehouse.OtherStore
                    .OrderBy(m => m.OtherStoreId)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                ListView = new ListView
                {
                    EntitiesPerPages = PageSize,
                    CurrentPage = page,
                    TotalEntities = _repositoryPCBwarehouse.OtherStore.Count()

                }
            };
            return View(model);
        }

        public async Task<ActionResult> Details_OtherStore(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.OtherStore.FirstOrDefaultAsync(m => m.OtherStoreId == id);

            IMapper map = MappingConfig.MapperConfigOtherStore.CreateMapper();
            OtherStoreViewModel context = map.Map<OtherStoreViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        public ActionResult Create_OtherStore()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_OtherStore([Bind(Include = "OtherStoreId,ValueItemOne,ValueItemTwo,DescriptionItemOne,DescriptionItemTwo,DescriptionItemThree,CountItem,LastUpdate")] OtherStoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.LastUpdate = DateTime.Now;

                    IMapper map = MappingConfig.MapperConfigOtherStore.CreateMapper();
                    OtherStore context = map.Map<OtherStore>(model);

                    await _repositoryPCBwarehouse.AddOtherStoreAsync(context);

                    ModelState.Clear();
                    return RedirectToAction("OtherStoreList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    ModelState.Clear();
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Edit_OtherStore(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.OtherStore.FirstOrDefaultAsync(m => m.OtherStoreId == id);

            IMapper map = MappingConfig.MapperConfigOtherStore.CreateMapper();
            OtherStoreViewModel context = map.Map<OtherStoreViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_OtherStore([Bind(Include = "OtherStoreId,ValueItemOne,ValueItemTwo,DescriptionItemOne,DescriptionItemTwo,DescriptionItemThree,CountItem,LastUpdate")] OtherStoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigOtherStore.CreateMapper();
                    OtherStore context = map.Map<OtherStore>(model);

                    await _repositoryPCBwarehouse.EditOtherStoreAsync(context);

                    return RedirectToAction("OtherStoreList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            return View(model);
        }


        public async Task<ActionResult> Delete_OtherStore(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.OtherStore.FirstOrDefaultAsync(m => m.OtherStoreId == id);

            IMapper map = MappingConfig.MapperConfigOtherStore.CreateMapper();
            OtherStoreViewModel context = map.Map<OtherStoreViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }


        [HttpPost, ActionName("Delete_OtherStore")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedOtherStore(int id)
        {
            try
            {
                var context = await _repositoryPCBwarehouse.OtherStore.FirstOrDefaultAsync(m => m.OtherStoreId == id);
                await _repositoryPCBwarehouse.DeleteOtherStoreAsync(context);

                return RedirectToAction("OtherStoreList");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return RedirectToAction("Delete_OtherStore", id);
        }
        #endregion

        #region CRUD Size
        public ActionResult SizeList(int page = 1)
        {
            SizeListViewModel model = new SizeListViewModel
            {
                Size = _repositoryPCBwarehouse.Size
                    .OrderBy(m => m.SizeId)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                ListView = new ListView
                {
                    EntitiesPerPages = PageSize,
                    CurrentPage = page,
                    TotalEntities = _repositoryPCBwarehouse.Size.Count()

                }
            };
            return View(model);
        }

        public async Task<ActionResult> Details_Size(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.Size.FirstOrDefaultAsync(m => m.SizeId == id);

            IMapper map = MappingConfig.MapperConfigSize.CreateMapper();
            SizeViewModel context = map.Map<SizeViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        public ActionResult Create_Size()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_Size([Bind(Include = "SizeId,Sizes")] SizeViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigSize.CreateMapper();
                    Size context = map.Map<Size>(model);

                    await _repositoryPCBwarehouse.AddSizeAsync(context);

                    ModelState.Clear();
                    return RedirectToAction("SizeList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    ModelState.Clear();
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Edit_Size(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.Size.FirstOrDefaultAsync(m => m.SizeId == id);

            IMapper map = MappingConfig.MapperConfigSize.CreateMapper();
            SizeViewModel context = map.Map<SizeViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_Size([Bind(Include = "SizeId,Sizes")] SizeViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigSize.CreateMapper();
                    Size context = map.Map<Size>(model);

                    await _repositoryPCBwarehouse.EditSizeAsync(context);

                    return RedirectToAction("SizeList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            return View(model);
        }


        public async Task<ActionResult> Delete_Size(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.Size.FirstOrDefaultAsync(m => m.SizeId == id);

            IMapper map = MappingConfig.MapperConfigSize.CreateMapper();
            SizeViewModel context = map.Map<SizeViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }


        [HttpPost, ActionName("Delete_Size")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedSize(int id)
        {
            try
            {
                var context = await _repositoryPCBwarehouse.Size.FirstOrDefaultAsync(m => m.SizeId == id);
                await _repositoryPCBwarehouse.DeleteSizeAsync(context);

                return RedirectToAction("SizeList");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return RedirectToAction("Delete_Size", id);
        }
        #endregion

        #region CRUD Package
        public ActionResult PackageList(int page = 1)
        {
            PackageListViewModel model = new PackageListViewModel
            {
                Package = _repositoryPCBwarehouse.Package
                    .OrderBy(m => m.PackagesId)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                ListView = new ListView
                {
                    EntitiesPerPages = PageSize,
                    CurrentPage = page,
                    TotalEntities = _repositoryPCBwarehouse.Package.Count()

                }
            };
            return View(model);
        }

        public async Task<ActionResult> Details_Package(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.Package.FirstOrDefaultAsync(m => m.PackagesId == id);

            IMapper map = MappingConfig.MapperConfigPackage.CreateMapper();
            PackageViewModel context = map.Map<PackageViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        public ActionResult Create_Package()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_Package([Bind(Include = "PackagesId,Packs")] PackageViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigPackage.CreateMapper();
                    Package context = map.Map<Package>(model);

                    await _repositoryPCBwarehouse.AddPackageAsync(context);

                    ModelState.Clear();
                    return RedirectToAction("PackageList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    ModelState.Clear();
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Edit_Package(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.Package.FirstOrDefaultAsync(m => m.PackagesId == id);

            IMapper map = MappingConfig.MapperConfigPackage.CreateMapper();
            PackageViewModel context = map.Map<PackageViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_Package([Bind(Include = "PackagesId,Packs")] PackageViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigPackage.CreateMapper();
                    Package context = map.Map<Package>(model);

                    await _repositoryPCBwarehouse.EditPackageAsync(context);

                    return RedirectToAction("PackageList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            return View(model);
        }


        public async Task<ActionResult> Delete_Package(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.Package.FirstOrDefaultAsync(m => m.PackagesId == id);

            IMapper map = MappingConfig.MapperConfigPackage.CreateMapper();
            PackageViewModel context = map.Map<PackageViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }


        [HttpPost, ActionName("Delete_Package")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedPackage(int id)
        {
            try
            {
                var context = await _repositoryPCBwarehouse.Package.FirstOrDefaultAsync(m => m.PackagesId == id);
                await _repositoryPCBwarehouse.DeletePackageAsync(context);

                return RedirectToAction("PackageList");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return RedirectToAction("Delete_Package", id);
        }
        #endregion

        #region CRUD SMD
        public ActionResult SMDList(int page = 1)
        {
            SMDListViewModel model = new SMDListViewModel
            {
                SMD = _repositoryPCBwarehouse.SMD
                    .Include(h => h.Item)
                    .Include(h => h.Packages)
                    .OrderBy(m => m.SMDId)
                    .AsEnumerable()
                    .Reverse()
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                ListView = new ListView
                {
                    EntitiesPerPages = PageSize,
                    CurrentPage = page,
                    TotalEntities = _repositoryPCBwarehouse.SMD.Count()

                }
            };

            return View(model);
        }

        public async Task<ActionResult> Details_SMD(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.SMD.FirstOrDefaultAsync(m => m.SMDId == id);

            IMapper map = MappingConfig.MapperConfigSMD.CreateMapper();
            SMDViewModel context = map.Map<SMDViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }
            return View(context);
        }

        public ActionResult Create_SMD()
        {
            ViewBag.ItemId = new SelectList(_repositoryPCBwarehouse.Item, "ItemId", "NameItem");
            ViewBag.PackagesId = new SelectList(_repositoryPCBwarehouse.Package, "PackagesId", "Packs");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create_SMD([Bind(Include = "SMDId,ValueItem,RatedItem,DescriptionItem,Feeder,CountItem,LastUpdate,ItemId,PackagesId")] SMDViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.LastUpdate = DateTime.Now;

                    IMapper map = MappingConfig.MapperConfigSMD.CreateMapper();
                    SMD context = map.Map<SMD>(model);

                    await _repositoryPCBwarehouse.AddSMDAsync(context);

                    ModelState.Clear();
                    return RedirectToAction("SMDList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    ModelState.Clear();
                }
            }
            ViewBag.ItemId = new SelectList(_repositoryPCBwarehouse.Item, "ItemId", "NameItem", model.ItemId);
            ViewBag.PackagesId = new SelectList(_repositoryPCBwarehouse.Package, "PackagesId", "Packs", model.PackagesId);
            return View(model);
        }

        public async Task<ActionResult> Edit_SMD(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.SMD.FirstOrDefaultAsync(m => m.SMDId == id);

            IMapper map = MappingConfig.MapperConfigSMD.CreateMapper();
            SMDViewModel context = map.Map<SMDViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }

            ViewBag.ItemId = new SelectList(_repositoryPCBwarehouse.Item, "ItemId", "NameItem", model.ItemId);
            ViewBag.PackagesId = new SelectList(_repositoryPCBwarehouse.Package, "PackagesId", "Packs", model.PackagesId);
            return View(context);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit_SMD([Bind(Include = "SMDId,ValueItem,RatedItem,DescriptionItem,Feeder,CountItem,LastUpdate,ItemId,PackagesId")] SMDViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    IMapper map = MappingConfig.MapperConfigSMD.CreateMapper();
                    SMD context = map.Map<SMD>(model);

                    await _repositoryPCBwarehouse.EditSMDAsync(context);

                    return RedirectToAction("SMDList");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            ViewBag.ItemId = new SelectList(_repositoryPCBwarehouse.Item, "ItemId", "NameItem", model.ItemId);
            ViewBag.PackagesId = new SelectList(_repositoryPCBwarehouse.Package, "PackagesId", "Packs", model.PackagesId);
            return View(model);
        }


        public async Task<ActionResult> Delete_SMD(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _repositoryPCBwarehouse.SMD.FirstOrDefaultAsync(m => m.SMDId == id);

            IMapper map = MappingConfig.MapperConfigSMD.CreateMapper();
            SMDViewModel context = map.Map<SMDViewModel>(model);

            if (context == null)
            {
                return HttpNotFound();
            }

            ViewBag.ItemId = new SelectList(_repositoryPCBwarehouse.Item, "ItemId", "NameItem", model.ItemId);
            ViewBag.PackagesId = new SelectList(_repositoryPCBwarehouse.Package, "PackagesId", "Packs", model.PackagesId);
            return View(context);
        }


        [HttpPost, ActionName("Delete_SMD")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedSMD(int id)
        {
            try
            {
                var context = await _repositoryPCBwarehouse.SMD.FirstOrDefaultAsync(m => m.SMDId == id);
                await _repositoryPCBwarehouse.DeleteSMDAsync(context);

                return RedirectToAction("SMDList");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return RedirectToAction("Delete_SMD", id);
        }
        #endregion

        #region CRUD HangingItemMap

        #endregion

        #region CRUD SMDItemMap

        #endregion

        #region CRUD Board

        #endregion

        /// <summary>
        /// Bads the action.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">You forgot to implement this ACTION!</exception>
        public ActionResult BadAction()
        {
            throw new Exception("You forgot to implement this ACTION!");
        }
    }
}