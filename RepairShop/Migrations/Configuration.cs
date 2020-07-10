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

        protected override void Seed(DAL.RepairShopContext context)
        {
            List<RepairOrder> repairOrders = new List<RepairOrder>
            {
                new RepairOrder{StartDate=DateTime.Parse("06-07-2020"), EndDate=DateTime.Parse("19-07-2020"), RepairStatus=RepairStatus.Finished},
                new RepairOrder{StartDate=DateTime.Parse("04-07-2020"), EndDate=DateTime.Parse("20-07-2020"), RepairStatus=RepairStatus.Awaiting},
                new RepairOrder{StartDate=DateTime.Parse("12-07-2020"), EndDate=DateTime.Parse("19-07-2020"), RepairStatus=RepairStatus.InProgress },
                new RepairOrder{StartDate=DateTime.Parse("20-07-2020"), EndDate=DateTime.Parse("29-07-2020"), RepairStatus=RepairStatus.Awaiting},
                new RepairOrder{StartDate=DateTime.Parse("29-08-2020"), EndDate=DateTime.Parse("29-07-2020"), RepairStatus=RepairStatus.Awaiting},
                new RepairOrder{StartDate=DateTime.Parse("20-07-2020"), EndDate=DateTime.Parse("29-07-2020"), RepairStatus=RepairStatus.AwaitingParts},
            };
            repairOrders.ForEach(s => context.RepairOrders.Add(s));
            context.SaveChanges();
        }
    }
}
