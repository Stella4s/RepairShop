using RepairShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairShop.ViewModels
{
    public class RepairOrderVMEdit
    {
        public RepairOrder RepairOrder { get; set; }
        public IEnumerable<Technician> Technicians { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public int CustomerId { get; set; }
    }
}