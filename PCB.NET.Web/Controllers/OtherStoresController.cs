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
    public class OtherStoresController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: OtherStores
        public async Task<ActionResult> Index()
        {
            var otherStores = db.OtherStores;
            return View(await otherStores.ToListAsync());
        }

        // GET: OtherStores/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherStore otherStore = await db.OtherStores.FindAsync(id);
            if (otherStore == null)
            {
                return HttpNotFound();
            }
            return View(otherStore);
        }

        // GET: OtherStores/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "NameItem");
            return View();
        }

        // POST: OtherStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OtherStoreId,ValueItemOne,ValueItemTwo,DescriptionItemOne,DescriptionItemTwo,DescriptionItemThree,CountItem,LastUpdate,ItemId")] OtherStore otherStore)
        {
            if (ModelState.IsValid)
            {
                db.OtherStores.Add(otherStore);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(otherStore);
        }

        // GET: OtherStores/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherStore otherStore = await db.OtherStores.FindAsync(id);
            if (otherStore == null)
            {
                return HttpNotFound();
            }

            return View(otherStore);
        }

        // POST: OtherStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OtherStoreId,ValueItemOne,ValueItemTwo,DescriptionItemOne,DescriptionItemTwo,DescriptionItemThree,CountItem,LastUpdate,ItemId")] OtherStore otherStore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otherStore).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
         
            return View(otherStore);
        }

        // GET: OtherStores/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherStore otherStore = await db.OtherStores.FindAsync(id);
            if (otherStore == null)
            {
                return HttpNotFound();
            }
            return View(otherStore);
        }

        // POST: OtherStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OtherStore otherStore = await db.OtherStores.FindAsync(id);
            db.OtherStores.Remove(otherStore);
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
