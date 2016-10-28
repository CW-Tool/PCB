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
    public class HangingsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: Hangings
        public async Task<ActionResult> Index()
        {
            var hangings = db.Hangings.Include(h => h.Item).Include(h => h.Size);
            return View(await hangings.ToListAsync());
        }

        // GET: Hangings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanging hanging = await db.Hangings.FindAsync(id);
            if (hanging == null)
            {
                return HttpNotFound();
            }
            return View(hanging);
        }

        // GET: Hangings/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameItem");
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "Sizes");
            return View();
        }

        // POST: Hangings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HangingId,ValueItem,RatedItem,DescriptionItem,CountItem,LastUpdate,ItemId,SizeId")] Hanging hanging)
        {
            if (ModelState.IsValid)
            {
                db.Hangings.Add(hanging);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameItem", hanging.ItemId);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "Sizes", hanging.SizeId);
            return View(hanging);
        }

        // GET: Hangings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanging hanging = await db.Hangings.FindAsync(id);
            if (hanging == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameItem", hanging.ItemId);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "Sizes", hanging.SizeId);
            return View(hanging);
        }

        // POST: Hangings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "HangingId,ValueItem,RatedItem,DescriptionItem,CountItem,LastUpdate,ItemId,SizeId")] Hanging hanging)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hanging).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameItem", hanging.ItemId);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "Sizes", hanging.SizeId);
            return View(hanging);
        }

        // GET: Hangings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hanging hanging = await db.Hangings.FindAsync(id);
            if (hanging == null)
            {
                return HttpNotFound();
            }
            return View(hanging);
        }

        // POST: Hangings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Hanging hanging = await db.Hangings.FindAsync(id);
            db.Hangings.Remove(hanging);
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
