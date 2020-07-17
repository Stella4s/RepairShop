using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RepairShop.DAL;
using RepairShop.Models;
using RepairShop.ViewModels;

namespace RepairShop.Controllers
{
    public class StockPartsController : Controller
    {
        private RepairShopContext db = new RepairShopContext();

        // GET: StockParts
        public ActionResult Index()
        {

            
            IQueryable<StockGroup> data =  from part in db.CatlParts
                                            join stock in db.StockParts on part equals stock.Part into j
                                            from item in j
                                            group item by new { item.Part.PartName, item.PartStatus, item.Part.Price } into g
                                            select new StockGroup
                                            {
                                                GroupedStockParts = g.ToList(),
                                                PartName = g.Key.PartName,
                                                StockStatus = g.Key.PartStatus,
                                                PartPrice = g.Key.Price,
                                                Count = g.Count()
                                            };


            return View(data);
        }

        // GET: StockParts/Details/5
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

        // GET: StockParts/Create
        public ActionResult Create()
        {
            ViewBag.CatlPartId = new SelectList(db.CatlParts, "CatlPartId", "PartName");
            return View();
        }

        // POST: StockParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StockPartID,CatlPartId,PartStatus")] StockPart stockGroup)
        {
            //StockPart stp = new StockPart()
            //{
            //    StockPartID = ,
            //    CatlPartId = ,
            //};

            if (ModelState.IsValid)
            {
            //    for (int i = 0; i < stockGroup.Count; i++)
            //    {

            //    }
                db.StockParts.Add(stockGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatlPartId = new SelectList(db.CatlParts, "CatlPartId", "PartName", stockGroup.StockPartID);
            return View(stockGroup);
        }

        // GET: StockParts/Edit/5
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
            //ViewBag.CatlPartId = new SelectList(db.CatlParts, "CatlPartId", "PartName", stockPart.CatlPartID);
            return View(stockPart);
        }

        // POST: StockParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StockPartID,CatlPartId,PartStatus")] StockPart stockPart)
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

        // GET: StockParts/Delete/5
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

        // POST: StockParts/Delete/5
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
