using RepairShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairShop.ViewModels
{
    public class StockViewModel
    {
        public StockViewModel(IQueryable<StockGroup> sg)//, IQueryable<StockPart> sp)
        {
            StockGroup = sg;
            //StockParts = sp;
        }
        public IQueryable StockGroup { get; set; }
        public IQueryable StockParts { get; set; }
    }
}