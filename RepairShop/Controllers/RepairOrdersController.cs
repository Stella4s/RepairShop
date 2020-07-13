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
using RepairShop.ViewModels;

namespace RepairShop.Controllers
{
    public class RepairOrdersController : Controller
    {
        private RepairShopContext db = new RepairShopContext();

        // GET: RepairOrders
        public ActionResult Index()
        {
            var vm = new RepairOrderVMIndex();
            //Add RepairOrders to List.
            vm.RepairOrders = db.RepairOrders.ToList();


            //Make RepairStatusGroup from RepairOrders.
            IQueryable<RepairStatusGroup> data = from order in db.RepairOrders
                                                 group order by order.RepairStatus into statusGroup
                                                 select new RepairStatusGroup()
                                                 {
                                                     RepairStatus = statusGroup.Key,
                                                     StatusCount = statusGroup.Count(),
                                                 };
            vm.RepairStatusGroups = data.ToList();
            return View(vm);
        }

        // GET: RepairOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairOrder repairOrder = db.RepairOrders.Find(id);
            if (repairOrder == null)
            {
                return HttpNotFound();
            }
            return View(repairOrder);
        }

        // GET: RepairOrders/Create
        public ActionResult Create()
        {
            RepairOrderVMEdit repairOrderVM = new RepairOrderVMEdit
            {
                Customers = db.Customers.ToList(),
                Technicians = db.Technicians.ToList()
            };

            return View(repairOrderVM);
        }

        // POST: RepairOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StartDate,EndDate,RepairStatus,Customer,Technician,HoursWorkedOn,Description")] RepairOrder repairOrder ,RepairOrderVMEdit repairOrderVM)
        {
            if (ModelState.IsValid)
            {
                repairOrder.Customer = db.Customers.Find(repairOrderVM.CustomerId);
                repairOrder.Technician = db.Technicians.Find(repairOrderVM.TechnicianId);
                db.RepairOrders.Add(repairOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repairOrderVM);
        }

        // GET: RepairOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RepairOrderVMEdit repairOrderVM = new RepairOrderVMEdit
            {
                RepairOrder = db.RepairOrders.Find(id),
                Technicians = db.Technicians.ToList(),
                Customers = db.Customers.ToList(),
            };
            try
            {
                repairOrderVM.CustomerId = repairOrderVM.RepairOrder.Customer.ID;
                repairOrderVM.TechnicianId = repairOrderVM.RepairOrder.Technician.ID;
            }
            catch
            {
                repairOrderVM.CustomerId = 1;
                repairOrderVM.TechnicianId = 1;
            }
            //RepairOrder repairOrder = db.RepairOrders.Find(id);
            if (repairOrderVM == null)
            {
                return HttpNotFound();
            }
            return View(repairOrderVM);
        }

        // POST: RepairOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, StartDate, EndDate, RepairStatus, Customer, Technician, HoursWorkedOn, Description, RepairOrder, CustomerId")] RepairOrderVMEdit repairOrderVM, int? CustomerId)
        {
            if (ModelState.IsValid)
            {
                RepairOrder repairOrder = repairOrderVM.RepairOrder;
                //If CustomerId has a value. (Which means the list was changed?)
                //Find Customer in Customers and set it to be repairOrder's Customer?
                if (CustomerId.HasValue)
                {
                    Customer customer = db.Customers.Find(CustomerId);
                    repairOrder.Customer = customer;
                }
                db.Entry(repairOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repairOrderVM);
        }

        // GET: RepairOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairOrder repairOrder = db.RepairOrders.Find(id);
            if (repairOrder == null)
            {
                return HttpNotFound();
            }
            return View(repairOrder);
        }

        // POST: RepairOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepairOrder repairOrder = db.RepairOrders.Find(id);
            db.RepairOrders.Remove(repairOrder);
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
