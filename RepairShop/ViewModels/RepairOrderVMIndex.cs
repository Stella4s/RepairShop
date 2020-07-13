using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepairShop.Models;

namespace RepairShop.ViewModels
{
    public class RepairOrderVMIndex
    {
        public IEnumerable<RepairOrder> RepairOrders { get; set; }
        public IEnumerable<RepairStatusGroup> RepairStatusGroups { get; set; }
    }
}