using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairShop.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal HourPrice { get; set; }
    }
}