using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepairShop.DAL;
using RepairShop.ViewModels;

namespace RepairShop.Controllers
{
    public class HomeController : Controller
    {
        private RepairShopContext db = new RepairShopContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<RepairStatusGroup> data = from order in db.RepairOrders
                                                 group order by order.RepairStatus into statusGroup
                                                 select new RepairStatusGroup()
                                                 {
                                                     RepairStatus = statusGroup.Key,
                                                     StatusCount = statusGroup.Count()
                                                   };
            ViewBag.Message = "Your application description page.";

            return View(data.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}