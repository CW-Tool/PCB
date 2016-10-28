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
    public class GasBalloonsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: GasBalloons
        public async Task<ActionResult> Index()
        {
            return View(await db.GasBalloons.ToListAsync());
        }

        // GET: GasBalloons/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasBalloon gasBalloon = await db.GasBalloons.FindAsync(id);
            if (gasBalloon == null)
            {
                return HttpNotFound();
            }
            return View(gasBalloon);
        }

        // GET: GasBalloons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GasBalloons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GasBalloonId,BalloonNumber,DateNextModified,LastUpdate")] GasBalloon gasBalloon)
        {
            if (ModelState.IsValid)
            {
                db.GasBalloons.Add(gasBalloon);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(gasBalloon);
        }

        // GET: GasBalloons/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasBalloon gasBalloon = await db.GasBalloons.FindAsync(id);
            if (gasBalloon == null)
            {
                return HttpNotFound();
            }
            return View(gasBalloon);
        }

        // POST: GasBalloons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GasBalloonId,BalloonNumber,DateNextModified,LastUpdate")] GasBalloon gasBalloon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasBalloon).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gasBalloon);
        }

        // GET: GasBalloons/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasBalloon gasBalloon = await db.GasBalloons.FindAsync(id);
            if (gasBalloon == null)
            {
                return HttpNotFound();
            }
            return View(gasBalloon);
        }

        // POST: GasBalloons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GasBalloon gasBalloon = await db.GasBalloons.FindAsync(id);
            db.GasBalloons.Remove(gasBalloon);
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
