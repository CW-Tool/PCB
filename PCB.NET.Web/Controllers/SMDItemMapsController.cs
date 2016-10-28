using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PCB.NET.Domain.Model;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;

namespace PCB.NET.Web.Controllers
{
    public class SMDItemMapsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: SMDItemMaps
        public async Task<ActionResult> Index()
        {
            var sMDItemMaps = db.SMDItemMaps.Include(s => s.Board).Include(s => s.Smd);
            return View(await sMDItemMaps.ToListAsync());
        }

        // GET: SMDItemMaps/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMDItemMap sMDItemMap = await db.SMDItemMaps.FindAsync(id);
            if (sMDItemMap == null)
            {
                return HttpNotFound();
            }
            return View(sMDItemMap);
        }

        // GET: SMDItemMaps/Create
        public ActionResult Create()
        {
            ViewBag.BoardId = new SelectList(db.Boards, "BoardId", "NameBlock");
            ViewBag.SmdId = new SelectList(db.SMDs, "SMDId", "ValueItem");
            return View();
        }

        // POST: SMDItemMaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SMDItemId,NameItem,BoardId,SmdId")] SMDItemMap sMDItemMap)
        {
            if (ModelState.IsValid)
            {
                db.SMDItemMaps.Add(sMDItemMap);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BoardId = new SelectList(db.Boards, "BoardId", "NameBlock", sMDItemMap.BoardId);
            ViewBag.SmdId = new SelectList(db.SMDs, "SMDId", "ValueItem", sMDItemMap.SmdId);
            return View(sMDItemMap);
        }

        // GET: SMDItemMaps/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMDItemMap sMDItemMap = await db.SMDItemMaps.FindAsync(id);
            if (sMDItemMap == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoardId = new SelectList(db.Boards, "BoardId", "NameBlock", sMDItemMap.BoardId);
            ViewBag.SmdId = new SelectList(db.SMDs, "SMDId", "ValueItem", sMDItemMap.SmdId);
            return View(sMDItemMap);
        }

        // POST: SMDItemMaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SMDItemId,NameItem,BoardId,SmdId")] SMDItemMap sMDItemMap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMDItemMap).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BoardId = new SelectList(db.Boards, "BoardId", "NameBlock", sMDItemMap.BoardId);
            ViewBag.SmdId = new SelectList(db.SMDs, "SMDId", "ValueItem", sMDItemMap.SmdId);
            return View(sMDItemMap);
        }

        // GET: SMDItemMaps/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMDItemMap sMDItemMap = await db.SMDItemMaps.FindAsync(id);
            if (sMDItemMap == null)
            {
                return HttpNotFound();
            }
            return View(sMDItemMap);
        }

        // POST: SMDItemMaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SMDItemMap sMDItemMap = await db.SMDItemMaps.FindAsync(id);
            db.SMDItemMaps.Remove(sMDItemMap);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
