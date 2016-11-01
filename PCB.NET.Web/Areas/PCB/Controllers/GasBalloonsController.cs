using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PCB.NET.Domain.Model;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;

namespace PCB.NET.Web.Areas.PCB.Controllers
{
    public class GasBalloonsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: PCB/GasBalloons
        public ActionResult Index()
        {
            return View(db.GasBalloons.ToList());
        }

        // GET: PCB/GasBalloons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasBalloon gasBalloon = db.GasBalloons.Find(id);
            if (gasBalloon == null)
            {
                return HttpNotFound();
            }
            return View(gasBalloon);
        }

        // GET: PCB/GasBalloons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PCB/GasBalloons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GasBalloonId,BalloonNumber,DateNextModified,LastUpdate")] GasBalloon gasBalloon)
        {
            if (ModelState.IsValid)
            {
                db.GasBalloons.Add(gasBalloon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gasBalloon);
        }

        // GET: PCB/GasBalloons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasBalloon gasBalloon = db.GasBalloons.Find(id);
            if (gasBalloon == null)
            {
                return HttpNotFound();
            }
            return View(gasBalloon);
        }

        // POST: PCB/GasBalloons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GasBalloonId,BalloonNumber,DateNextModified,LastUpdate")] GasBalloon gasBalloon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasBalloon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gasBalloon);
        }

        // GET: PCB/GasBalloons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasBalloon gasBalloon = db.GasBalloons.Find(id);
            if (gasBalloon == null)
            {
                return HttpNotFound();
            }
            return View(gasBalloon);
        }

        // POST: PCB/GasBalloons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GasBalloon gasBalloon = db.GasBalloons.Find(id);
            db.GasBalloons.Remove(gasBalloon);
            db.SaveChanges();
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
