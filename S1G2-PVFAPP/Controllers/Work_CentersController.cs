using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S1G2_PVFAPP.Models;

namespace S1G2_PVFAPP.Controllers
{
    public class Work_CentersController : Controller
    {
        private Entities6 db = new Entities6();

        // GET: Work_Centers
        public ActionResult Index()
        {
            return View(db.Work_centers.ToList());
        }

        // GET: Work_Centers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_center work_center = db.Work_centers.Find(id);
            if (work_center == null)
            {
                return HttpNotFound();
            }
            return View(work_center);
        }

        // GET: Work_Centers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Work_Centers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkcenterID,WorkcenterName")] Work_center work_center)
        {
            if (ModelState.IsValid)
            {
                db.Work_centers.Add(work_center);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(work_center);
        }

        // GET: Work_Centers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_center work_center = db.Work_centers.Find(id);
            if (work_center == null)
            {
                return HttpNotFound();
            }
            return View(work_center);
        }

        // POST: Work_Centers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkcenterID,WorkcenterName")] Work_center work_center)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_center).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work_center);
        }

        // GET: Work_Centers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_center work_center = db.Work_centers.Find(id);
            if (work_center == null)
            {
                return HttpNotFound();
            }
            return View(work_center);
        }

        // POST: Work_Centers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Work_center work_center = db.Work_centers.Find(id);
            db.Work_centers.Remove(work_center);
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
