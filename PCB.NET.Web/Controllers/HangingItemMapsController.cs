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
    public class HangingItemMapsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: HangingItemMaps
        public async Task<ActionResult> Index()
        {
            var hangingItemMaps = db.HangingItemMaps.Include(h => h.Board).Include(h => h.Hanging);
            return View(await hangingItemMaps.ToListAsync());
        }

        // GET: HangingItemMaps/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangingItemMap hangingItemMap = await db.HangingItemMaps.FindAsync(id);
            HangingItemMap hanging = new HangingItemMap
            {
                Board = db.Boards.FirstOrDefault(m => m.BoardId == hangingItemMap.BoardId),
                Hanging = db.Hangings.FirstOrDefault(m => m.HangingId == hangingItemMap.HangingId),
                NameItem = hangingItemMap.NameItem
            };
            if (hangingItemMap == null)
            {
                return HttpNotFound();
            }
            return View(hanging);
        }

        // GET: HangingItemMaps/Create
        public ActionResult Create()
        {
            ViewBag.BoardId = new SelectList(db.Boards, "BoardId", "NameBlock");
            ViewBag.HangingId = new SelectList(db.Hangings, "HangingId", "ValueItem");
            return View();
        }

        // POST: HangingItemMaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HangingItemId,NameItem,HangingId,BoardId")] HangingItemMap hangingItemMap)
        {
            if (ModelState.IsValid)
            {
                db.HangingItemMaps.Add(hangingItemMap);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BoardId = new SelectList(db.Boards, "BoardId", "NameBlock", hangingItemMap.BoardId);
            ViewBag.HangingId = new SelectList(db.Hangings, "HangingId", "ValueItem", hangingItemMap.HangingId);
            return View(hangingItemMap);
        }

        // GET: HangingItemMaps/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangingItemMap hangingItemMap = await db.HangingItemMaps.FindAsync(id);
            if (hangingItemMap == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoardId = new SelectList(db.Boards, "BoardId", "NameBlock", hangingItemMap.BoardId);
            ViewBag.HangingId = new SelectList(db.Hangings, "HangingId", "ValueItem", hangingItemMap.HangingId);
            return View(hangingItemMap);
        }

        // POST: HangingItemMaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "HangingItemId,NameItem,HangingId,BoardId")] HangingItemMap hangingItemMap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangingItemMap).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BoardId = new SelectList(db.Boards, "BoardId", "NameBlock", hangingItemMap.BoardId);
            ViewBag.HangingId = new SelectList(db.Hangings, "HangingId", "ValueItem", hangingItemMap.HangingId);
            return View(hangingItemMap);
        }

        // GET: HangingItemMaps/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangingItemMap hangingItemMap = await db.HangingItemMaps.FindAsync(id);
            if (hangingItemMap == null)
            {
                return HttpNotFound();
            }
            return View(hangingItemMap);
        }

        // POST: HangingItemMaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HangingItemMap hangingItemMap = await db.HangingItemMaps.FindAsync(id);
            db.HangingItemMaps.Remove(hangingItemMap);
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
