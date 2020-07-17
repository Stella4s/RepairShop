using RepairShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace RepairShop.ViewModels
{
    public class StockGroup
    {
        [DisplayName("Id")]
        public List<StockPart> GroupedStockParts { get; set; }

        [DisplayName("Amount")]
        public int Count { get; set; }

        [DisplayName("Status")]
        public PartStatus StockStatus { get; set; }

        [DisplayName("Name")]
        public string PartName { get; set; }

        [DisplayName("Price")]
        public decimal PartPrice { get; set; }

    }
}