using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PCB.NET.Domain.Model;
using PCB.NET.Domain.Model.Warehouse;

namespace PCB.NET.Controllers
{
    public class SMDsController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: SMDs
        public ActionResult Index()
        {
            return View(db.SMDs.ToList());
        }

        // GET: SMDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMD sMD = db.SMDs.Find(id);
            if (sMD == null)
            {
                return HttpNotFound();
            }
            return View(sMD);
        }

        // GET: SMDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SMDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SMDId,Value,DescriptionItem,Packages,Feeder,CountItem,LastUpdate")] SMD sMD)
        {
            if (ModelState.IsValid)
            {
                db.SMDs.Add(sMD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sMD);
        }

        // GET: SMDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMD sMD = db.SMDs.Find(id);
            if (sMD == null)
            {
                return HttpNotFound();
            }
            return View(sMD);
        }

        // POST: SMDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SMDId,Value,DescriptionItem,Packages,Feeder,CountItem,LastUpdate")] SMD sMD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sMD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sMD);
        }

        // GET: SMDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMD sMD = db.SMDs.Find(id);
            if (sMD == null)
            {
                return HttpNotFound();
            }
            return View(sMD);
        }

        // POST: SMDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SMD sMD = db.SMDs.Find(id);
            db.SMDs.Remove(sMD);
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
