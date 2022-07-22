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
    public class Room_UsageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Room_Usage
        public async Task<ActionResult> Index()
        {
            return View(await db.Room_Usage.ToListAsync());
        }

        // GET: Room_Usage/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Usage room_Usage = await db.Room_Usage.FindAsync(id);
            if (room_Usage == null)
            {
                return HttpNotFound();
            }
            return View(room_Usage);
        }

        // GET: Room_Usage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room_Usage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Email,ContactNo,NoOfAdult,NoOfChildren,Checkin,Checkout,TransactionNo,Note,RoomID")] Room_Usage room_Usage)
        {
            if (ModelState.IsValid)
            {
                db.Room_Usage.Add(room_Usage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(room_Usage);
        }

        // GET: Room_Usage/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Usage room_Usage = await db.Room_Usage.FindAsync(id);
            if (room_Usage == null)
            {
                return HttpNotFound();
            }
            return View(room_Usage);
        }

        // POST: Room_Usage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Email,ContactNo,NoOfAdult,NoOfChildren,Checkin,Checkout,TransactionNo,Note,RoomID")] Room_Usage room_Usage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room_Usage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(room_Usage);
        }

        // GET: Room_Usage/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Usage room_Usage = await db.Room_Usage.FindAsync(id);
            if (room_Usage == null)
            {
                return HttpNotFound();
            }
            return View(room_Usage);
        }

        // POST: Room_Usage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Room_Usage room_Usage = await db.Room_Usage.FindAsync(id);
            db.Room_Usage.Remove(room_Usage);
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
