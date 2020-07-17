using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepairShop.Models;

namespace RepairShop.ViewModels
{
    public class VMRepairOrderIndex
    {
        public IEnumerable<RepairOrder> RepairOrders { get; set; }
        public IEnumerable<RepairStatusGroup> RepairStatusGroups { get; set; }
        public IEnumerable<Technician> Technicians { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}