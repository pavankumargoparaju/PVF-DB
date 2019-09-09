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
    public class ProductlinesController : Controller
    {
        private Entities6 db = new Entities6();

        // GET: Productlines
        public ActionResult Index()
        {
            return View(db.Productlines.ToList());
        }

        // GET: Productlines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productline productline = db.Productlines.Find(id);
            if (productline == null)
            {
                return HttpNotFound();
            }
            return View(productline);
        }

        // GET: Productlines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productlines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductlineID,LineName")] Productline productline)
        {
            if (ModelState.IsValid)
            {
                db.Productlines.Add(productline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productline);
        }

        // GET: Productlines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productline productline = db.Productlines.Find(id);
            if (productline == null)
            {
                return HttpNotFound();
            }
            return View(productline);
        }

        // POST: Productlines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductlineID,LineName")] Productline productline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productline);
        }

        // GET: Productlines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productline productline = db.Productlines.Find(id);
            if (productline == null)
            {
                return HttpNotFound();
            }
            return View(productline);
        }

        // POST: Productlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productline productline = db.Productlines.Find(id);
            db.Productlines.Remove(productline);
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
