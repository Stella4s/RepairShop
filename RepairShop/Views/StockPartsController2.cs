using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RepairShop.DAL;
using RepairShop.Models;

namespace RepairShop.Views
{
    public class StockPartsController2 : Controller
    {
        private RepairShopContext db = new RepairShopContext();

        // GET: StockPartsController2
        public ActionResult Index()
        {
            var stockParts = db.StockParts.Include(s => s.Part);
            return View(stockParts.ToList());
        }

        // GET: StockPartsController2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockPart stockPart = db.StockParts.Find(id);
            if (stockPart == null)
            {
                return HttpNotFound();
            }
            return View(stockPart);
        }

        // GET: StockPartsController2/Create
        public ActionResult Create()
        {
            ViewBag.CatlPartID = new SelectList(db.CatlParts, "CatlPartId", "PartName");
            return View();
        }

        // POST: StockPartsController2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StockPartID,CatlPartID,PartStatus")] StockPart stockPart)
        {
            if (ModelState.IsValid)
            {
                db.StockParts.Add(stockPart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatlPartID = new SelectList(db.CatlParts, "CatlPartId", "PartName", stockPart.StockPartID);
            return View(stockPart);
        }

        // GET: StockPartsController2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockPart stockPart = db.StockParts.Find(id);
            if (stockPart == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatlPartId = new SelectList(db.CatlParts, "CatlPartId", "PartName", stockPart.StockPartID);
            return View(stockPart);
        }

        // POST: StockPartsController2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StockPartID,CatlPartID,PartStatus")] StockPart stockPart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockPart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatlPartId = new SelectList(db.CatlParts, "CatlPartId", "PartName", stockPart.StockPartID);
            return View(stockPart);
        }

        // GET: StockPartsController2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockPart stockPart = db.StockParts.Find(id);
            if (stockPart == null)
            {
                return HttpNotFound();
            }
            return View(stockPart);
        }

        // POST: StockPartsController2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockPart stockPart = db.StockParts.Find(id);
            db.StockParts.Remove(stockPart);
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
