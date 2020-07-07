using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using RepairShop.Models;

namespace RepairShop.ViewModels
{
    public class RepairStatusGroup
    {
        [DisplayName("Status")]
        public RepairStatus RepairStatus { get; set; }
        [DisplayName("Count")]
        public int StatusCount { get; set; }
    }
}