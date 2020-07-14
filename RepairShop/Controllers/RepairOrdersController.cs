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
            var vm = new VMRepairOrderIndex
            {
                //Add RepairOrders to List.
                RepairOrders = db.RepairOrders.ToList()
            };

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
            VMRepairOrderEdit repairOrderVM = new VMRepairOrderEdit
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
        public ActionResult Create([Bind(Include = "ID,StartDate,EndDate,RepairStatus,Customer,Technician,HoursWorkedOn,Description")] RepairOrder repairOrder ,VMRepairOrderEdit repairOrderVM)
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

            VMRepairOrderEdit vmRepairOrder = new VMRepairOrderEdit
            {
                RepairOrder = db.RepairOrders.Find(id),
                Technicians = db.Technicians.ToList(),
                Customers = db.Customers.ToList(),
            };
            //Try to set it to the ID in RepairOrder.
            //So the dropdown list will display the name of the currently selected property.
            try {
                vmRepairOrder.CustomerId = vmRepairOrder.RepairOrder.Customer.ID;
            }
            catch {
                vmRepairOrder.CustomerId = 1;
            }
            try {
                vmRepairOrder.TechnicianId = vmRepairOrder.RepairOrder.Technician.ID;
            }
            catch {
                vmRepairOrder.TechnicianId = 1;
            }

            //RepairOrder repairOrder = db.RepairOrders.Find(id);
            if (vmRepairOrder == null)
            {
                return HttpNotFound();
            }
            return View(vmRepairOrder);
            }

        // POST: RepairOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, StartDate, EndDate, RepairStatus, Customer, Technician, HoursWorkedOn, Description, RepairOrder, CustomerId")] VMRepairOrderEdit vmRepairOrder)
        {
            if (ModelState.IsValid)
            {
                //Find the repairOrder in the database based on the ID.
                RepairOrder repairOrder = db.RepairOrders.Find(vmRepairOrder.RepairOrder.ID);

                //If CustomerId has a value. (Which means the list was changed?)
                //Find Customer in Customers and set it to be repairOrder's Customer?
                if (vmRepairOrder.CustomerId != null)
                {
                    //Load Customer first before altering. Otherwise Customer remains null.
                    db.Entry(repairOrder).Reference(c => c.Customer).Load();

                    //Find said Customer in the database and set it as the customer?
                    repairOrder.Customer = db.Customers.Find(vmRepairOrder.CustomerId);
                }
                if (vmRepairOrder.TechnicianId != null)
                {
                    db.Entry(repairOrder).Reference(c => c.Technician).Load();

                    repairOrder.Technician = db.Technicians.Find(vmRepairOrder.TechnicianId);
                }
                db.Entry(repairOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vmRepairOrder);
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
