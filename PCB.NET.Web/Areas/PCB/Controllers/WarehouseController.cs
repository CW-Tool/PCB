using AutoMapper;
using PCB.NET.Domain.Abstract.PCB;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Web.Areas.PCB.Models.WarehouseViewModel;
using System;
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
        public ActionResult GasBalloonList()
        {
            var model = _repositoryPCBwarehouse.SMD.OrderBy(m => m.ItemId).ToList();

            return View(model);
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Details_Balloon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _repositoryPCBwarehouse.GasBalloon.FirstOrDefault(m => m.GasBalloonId == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
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
        public ActionResult Edit_Balloon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _repositoryPCBwarehouse.GasBalloon.FirstOrDefault(m => m.GasBalloonId == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
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
        public ActionResult Delete_Balloon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _repositoryPCBwarehouse.GasBalloon.FirstOrDefault(m => m.GasBalloonId == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
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
                var context = _repositoryPCBwarehouse.GasBalloon.FirstOrDefault(m => m.GasBalloonId == id);
                await _repositoryPCBwarehouse.DeleteGasBalloonAsync(context);

                return RedirectToAction("GasBalloonList");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return View(id);
        }
        #endregion

        #region CRUD Hanging

        #endregion

        #region CRUD Item

        #endregion

        #region CRUD OtherStore

        #endregion

        #region CRUD Size

        #endregion

        #region CRUD Package

        #endregion

        #region CRUD SMD

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