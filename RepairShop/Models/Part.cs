using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairShop.Models
{
    public class Part
    {
        public int PartId { get; set; }
        public string PartName { get; set; }
        public decimal Price { get; set; }
        public PartStatus PartStatus { get; set; }
    }

    public enum PartStatus
    {
        InStock,
        Reserved,
        AwaitingArrival
    }
}