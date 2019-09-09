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
    public class Sales_PersonController : Controller
    {
        private Entities6 db = new Entities6();

        // GET: Sales_Person
        public ActionResult Index()
        {
            var sales_people = db.Sales_people.Include(s => s.Territory);
            return View(sales_people.ToList());
        }

        // GET: Sales_Person/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Person sales_Person = db.Sales_people.Find(id);
            if (sales_Person == null)
            {
                return HttpNotFound();
            }
            return View(sales_Person);
        }

        // GET: Sales_Person/Create
        public ActionResult Create()
        {
            ViewBag.TerritoryID = new SelectList(db.Territories, "TerritoryID", "TerritoryName");
            return View();
        }

        // POST: Sales_Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalespersonID,Name,Phone,Fax,TerritoryID")] Sales_Person sales_Person)
        {
            if (ModelState.IsValid)
            {
                db.Sales_people.Add(sales_Person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TerritoryID = new SelectList(db.Territories, "TerritoryID", "TerritoryName", sales_Person.TerritoryID);
            return View(sales_Person);
        }

        // GET: Sales_Person/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Person sales_Person = db.Sales_people.Find(id);
            if (sales_Person == null)
            {
                return HttpNotFound();
            }
            ViewBag.TerritoryID = new SelectList(db.Territories, "TerritoryID", "TerritoryName", sales_Person.TerritoryID);
            return View(sales_Person);
        }

        // POST: Sales_Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalespersonID,Name,Phone,Fax,TerritoryID")] Sales_Person sales_Person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales_Person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TerritoryID = new SelectList(db.Territories, "TerritoryID", "TerritoryName", sales_Person.TerritoryID);
            return View(sales_Person);
        }

        // GET: Sales_Person/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales_Person sales_Person = db.Sales_people.Find(id);
            if (sales_Person == null)
            {
                return HttpNotFound();
            }
            return View(sales_Person);
        }

        // POST: Sales_Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sales_Person sales_Person = db.Sales_people.Find(id);
            db.Sales_people.Remove(sales_Person);
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
