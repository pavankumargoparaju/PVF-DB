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
    public class Raw_MaterialController : Controller
    {
        private Entities6 db = new Entities6();

        // GET: Raw_Material
        public ActionResult Index()
        {
            return View(db.Raw_Materials.ToList());
        }

        // GET: Raw_Material/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raw_Material raw_Material = db.Raw_Materials.Find(id);
            if (raw_Material == null)
            {
                return HttpNotFound();
            }
            return View(raw_Material);
        }

        // GET: Raw_Material/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Raw_Material/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaterialID,MaterialName,Cost,UnitOfMeasure")] Raw_Material raw_Material)
        {
            if (ModelState.IsValid)
            {
                db.Raw_Materials.Add(raw_Material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(raw_Material);
        }

        // GET: Raw_Material/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raw_Material raw_Material = db.Raw_Materials.Find(id);
            if (raw_Material == null)
            {
                return HttpNotFound();
            }
            return View(raw_Material);
        }

        // POST: Raw_Material/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaterialID,MaterialName,Cost,UnitOfMeasure")] Raw_Material raw_Material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raw_Material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raw_Material);
        }

        // GET: Raw_Material/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raw_Material raw_Material = db.Raw_Materials.Find(id);
            if (raw_Material == null)
            {
                return HttpNotFound();
            }
            return View(raw_Material);
        }

        // POST: Raw_Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            
            List<Supply> supplymaterial = db.Supplies.OrderByDescending(p => p.MaterialID).ToList();
            for (int i = 0; i < supplymaterial.Count; i++) {
                string text = supplymaterial[i].MaterialID;
                Supply supplyMaterailId = db.Supplies.OrderByDescending(r => r.MaterialID == text).FirstOrDefault();
                db.Supplies.Remove(supplyMaterailId);
            }
                db.SaveChanges();
            Raw_Material raw_Material = db.Raw_Materials.Find(id);
            db.Raw_Materials.Remove(raw_Material);
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
