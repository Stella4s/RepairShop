namespace RepairShop.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RepairShop.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RepairShop.DAL.RepairShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RepairShop.DAL.RepairShopContext context)
        {
            List<RepairOrder> RepairOrders = new List<RepairOrder>
            {
                new RepairOrder{StartDate=DateTime.Parse("6/7/2020"), EndDate=DateTime.Parse("19/7/2020"), RepairStatus=RepairStatus.Finished},
                new RepairOrder{StartDate=DateTime.Parse("4/7/2020"), EndDate=DateTime.Parse("20/7/2020"), RepairStatus=RepairStatus.Awaiting},
                new RepairOrder{StartDate=DateTime.Parse("12/7/2020"), EndDate=DateTime.Parse("19/7/2020"), RepairStatus=RepairStatus.InProgress },
                new RepairOrder{StartDate=DateTime.Parse("20/7/2020"), EndDate=DateTime.Parse("29/7/2020"), RepairStatus=RepairStatus.Awaiting},
                new RepairOrder{StartDate=DateTime.Parse("20/7/2020"), EndDate=DateTime.Parse("29/7/2020"), RepairStatus=RepairStatus.AwaitingParts},
            };
        }
    }
}
