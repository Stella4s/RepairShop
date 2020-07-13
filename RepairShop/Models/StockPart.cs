using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RepairShop.Models
{
    public class StockPart
    {
        public int StockPartID { get; set; }
        public CatlPart Part {get; set;}
        public PartStatus PartStatus { get; set; }
    }

    public enum PartStatus
    {
        InStock,
        Reserved,
        AwaitingArrival
    }
}