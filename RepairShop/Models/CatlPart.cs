using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairShop.Models
{
    public class CatlPart
    {
        public int CatlPartId { get; set; }
        public string PartName { get; set; }
        public decimal Price { get; set; }
    }
}