using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DJResortWebsite.Models;

namespace DJResortWebsite.Controllers
{
    public class SpacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Spaces
        public async Task<ActionResult> Index()
        {
            return View(await db.Spaces.ToListAsync());
        }

        // GET: Spaces/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Space space = await db.Spaces.FindAsync(id);
            if (space == null)
            {
                return HttpNotFound();
            }
            return View(space);
        }

        // GET: Spaces/Create
        [Authorize(Roles = "Administratror")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administratror")]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Location,Type")] Space space)
        {
            if (ModelState.IsValid)
            {
                db.Spaces.Add(space);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(space);
        }

        // GET: Spaces/Edit/5
        [Authorize(Roles = "Administratror")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Space space = await db.Spaces.FindAsync(id);
            if (space == null)
            {
                return HttpNotFound();
            }
            return View(space);
        }

        // POST: Spaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administratror")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Location,Type")] Space space)
        {
            if (ModelState.IsValid)
            {
                db.Entry(space).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(space);
        }

        // GET: Spaces/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Space space = await db.Spaces.FindAsync(id);
            if (space == null)
            {
                return HttpNotFound();
            }
            return View(space);
        }

        // POST: Spaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Space space = await db.Spaces.FindAsync(id);
            db.Spaces.Remove(space);
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
