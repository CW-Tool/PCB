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
    public class BoardsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: Boards
        public async Task<ActionResult> Index()
        {
            var boards = db.Boards.Include(b => b.Dvc).Include(b => b.Ebso);
            return View(await boards.ToListAsync());
        }

        // GET: Boards/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = await db.Boards.FindAsync(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        // GET: Boards/Create
        public ActionResult Create()
        {
            ViewBag.BoardId = new SelectList(db.Dvcs.Select(m => m.TimeSecond), "Id", "Description");
            ViewBag.BoardId = new SelectList(db.Ebsos.Select(m => m.TimeSecond), "Id", "Description");
            return View();
        }

        // POST: Boards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BoardId,NameBlock,Make,CountBoard,Description,LastUpdate")] Board board)
        {
            if (ModelState.IsValid)
            {
                db.Boards.Add(board);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BoardId = new SelectList(db.Dvcs, "Id", "Description", board.BoardId);
            ViewBag.BoardId = new SelectList(db.Ebsos, "Id", "Description", board.BoardId);
            return View(board);
        }

        // GET: Boards/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = await db.Boards.FindAsync(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoardId = new SelectList(db.Dvcs.Select(m => m.TimeSecond), "Id", "Description", board.BoardId);
            ViewBag.BoardId = new SelectList(db.Ebsos.Select(m => m.TimeSecond), "Id", "Description", board.BoardId);
            return View(board);
        }

        // POST: Boards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BoardId,NameBlock,Make,CountBoard,Description,LastUpdate")] Board board)
        {
            if (ModelState.IsValid)
            {
                db.Entry(board).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BoardId = new SelectList(db.Dvcs, "Id", "Description", board.BoardId);
            ViewBag.BoardId = new SelectList(db.Ebsos, "Id", "Description", board.BoardId);
            return View(board);
        }

        // GET: Boards/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Board board = await db.Boards.FindAsync(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        // POST: Boards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Board board = await db.Boards.FindAsync(id);
            db.Boards.Remove(board);
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
