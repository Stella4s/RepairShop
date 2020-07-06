using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepairShop.Models;

namespace RepairShop.ViewModels
{
    public class RepairStatusGroup
    {
        public RepairStatus RepairStatus { get; set; }
        public int StatusCount { get; set; }
    }
}