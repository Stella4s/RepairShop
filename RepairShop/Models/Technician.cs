﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairShop.Models
{
    public class Technician : Person
    {
        public decimal HourPrice { get; set; }
    }
}