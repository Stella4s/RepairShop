using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RepairShop.Models
{
    public class Customer : Person
    {
        public string Email { get; set; }
    }
}