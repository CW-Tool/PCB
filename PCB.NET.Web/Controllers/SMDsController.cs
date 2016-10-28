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
    public class SMDsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: SMDs
        public async Task<ActionResult> Index()
        {
            var sMDs = db.SMDs.Include(s => s.Item).Include(s => s.Packages);
            return View(await sMDs.ToListAsync());
        }

        // GET: SMDs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMD sMD = await db.SMDs.FindAsync(id);
            if (sMD == null)
            {
                return HttpNotFound();
            }
            return View(sMD);
        }

        // GET: SMDs/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameItem");
            ViewBag.PackagesId = new SelectList(db.Packages, "PackagesId", "Packs");
            return View();
        }

        // POST: SMDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SMDId,ValueItem,RatedItem,DescriptionItem,Feeder,CountItem,LastUpdate,ItemId,PackagesId")] SMD sMD)
        {
            if (ModelState.IsValid)
            {
                db.SMDs.Add(sMD);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameItem", sMD.ItemId);
            ViewBag.PackagesId = new SelectList(db.Packages, "PackagesId", "Packs", sMD.PackagesId);
            return View(sMD);
        }

        // GET: SMDs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMD sMD = await db.SMDs.FindAsync(id);
            if (sMD == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameItem", sMD.ItemId);
            ViewBag.PackagesId = new SelectList(db.Packages, "PackagesId", "Packs", sMD.PackagesId);
            return View(sMD);
        }

        // POST: SMDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SMDId,ValueItem,RatedItem,DescriptionItem,Feeder,CountItem,LastUpdate,ItemId,PackagesId")] SMD sMD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMD).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameItem", sMD.ItemId);
            ViewBag.PackagesId = new SelectList(db.Packages, "PackagesId", "Packs", sMD.PackagesId);
            return View(sMD);
        }

        // GET: SMDs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMD sMD = await db.SMDs.FindAsync(id);
            if (sMD == null)
            {
                return HttpNotFound();
            }
            return View(sMD);
        }

        // POST: SMDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SMD sMD = await db.SMDs.FindAsync(id);
            db.SMDs.Remove(sMD);
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
