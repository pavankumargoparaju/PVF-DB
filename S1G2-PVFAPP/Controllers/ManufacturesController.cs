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
    public class ManufacturesController : Controller
    {
        private Entities6 db = new Entities6();

        // GET: Manufactures
        public ActionResult Index()
        {
            var manufactures = db.Manufactures.Include(m => m.Product).Include(m => m.Raw_Materials);
            return View(manufactures.ToList());
        }

        // GET: Manufactures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacture manufacture = db.Manufactures.Find(id);
            if (manufacture == null)
            {
                return HttpNotFound();
            }
            return View(manufacture);
        }

        // GET: Manufactures/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description");
            ViewBag.MaterialID = new SelectList(db.Raw_Materials, "MaterialID", "MaterialName");
            return View();
        }

        // POST: Manufactures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,MaterialID,Quantity")] Manufacture manufacture)
        {
            if (ModelState.IsValid)
            {
                db.Manufactures.Add(manufacture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description", manufacture.ProductID);
            ViewBag.MaterialID = new SelectList(db.Raw_Materials, "MaterialID", "MaterialName", manufacture.MaterialID);
            return View(manufacture);
        }

        // GET: Manufactures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacture manufacture = db.Manufactures.Find(id);
            if (manufacture == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description", manufacture.ProductID);
            ViewBag.MaterialID = new SelectList(db.Raw_Materials, "MaterialID", "MaterialName", manufacture.MaterialID);
            return View(manufacture);
        }

        // POST: Manufactures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,MaterialID,Quantity")] Manufacture manufacture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manufacture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Description", manufacture.ProductID);
            ViewBag.MaterialID = new SelectList(db.Raw_Materials, "MaterialID", "MaterialName", manufacture.MaterialID);
            return View(manufacture);
        }

        // GET: Manufactures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacture manufacture = db.Manufactures.Find(id);
            if (manufacture == null)
            {
                return HttpNotFound();
            }
            return View(manufacture);
        }

        // POST: Manufactures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Manufacture manufacture = db.Manufactures.Find(id);
            db.Manufactures.Remove(manufacture);
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
