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
            List<Customer> customers = new List<Customer>
            {
                new Customer{FirstName="Julia", LastName="Dekker", Email="J.Dekker@gmail.com"},
                new Customer{FirstName="Bob", LastName="Dekker", Email="Bob245@gmail.com"},
                new Customer{FirstName="Jan", LastName="Jansen", Email="JanJansen@gmail.com"},
                new Customer{FirstName="Klaas", LastName="van de Berg", Email="KlaasVDBerg@ziggo.nl"},
                new Customer{FirstName="Linda", LastName="Bakker", Email="xXL33TH4CK3RXx@gmail.com"},
            };
            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();

            List<Technician> technicians = new List<Technician>
            {
                new Technician{FirstName="Daan", LastName="van Leeuwen", HourPrice=(32.50M)},
                new Technician{FirstName="Henk", LastName="Koper", HourPrice=(30.20M)},
                new Technician{FirstName="Nienke", LastName="de Wit", HourPrice=(35M)},
                new Technician{FirstName="Martijn", LastName="de Boer", HourPrice=(34.50M)},
            };
            technicians.ForEach(s => context.Technicians.Add(s));
            context.SaveChanges();

            List<RepairOrder> repairOrders = new List<RepairOrder>
            {
                new RepairOrder{StartDate=DateTime.Parse("06-07-2020"), EndDate=DateTime.Parse("19-07-2020"), RepairStatus=RepairStatus.Finished, CustomerID=1, TechnicianID=4},
                new RepairOrder{StartDate=DateTime.Parse("04-07-2020"), EndDate=DateTime.Parse("20-07-2020"), RepairStatus=RepairStatus.Awaiting, CustomerID=5, TechnicianID=1},
                new RepairOrder{StartDate=DateTime.Parse("12-07-2020"), EndDate=DateTime.Parse("19-07-2020"), RepairStatus=RepairStatus.InProgress , CustomerID=1, TechnicianID=1},
                new RepairOrder{StartDate=DateTime.Parse("20-07-2020"), EndDate=DateTime.Parse("29-07-2020"), RepairStatus=RepairStatus.Awaiting, CustomerID=4, TechnicianID=3},
                new RepairOrder{StartDate=DateTime.Parse("29-08-2020"), EndDate=DateTime.Parse("29-07-2020"), RepairStatus=RepairStatus.Awaiting, CustomerID=3, TechnicianID=2},
                new RepairOrder{StartDate=DateTime.Parse("20-07-2020"), EndDate=DateTime.Parse("29-07-2020"), RepairStatus=RepairStatus.AwaitingParts, CustomerID=2, TechnicianID=3},
            };
            repairOrders.ForEach(s => context.RepairOrders.Add(s));
            context.SaveChanges();

            List<CatlPart> cParts = new List<CatlPart>
            {
                new CatlPart{PartName="Omega Vers. A",  Price=59.20M},
                new CatlPart{PartName="Omega Vers. B",  Price=60M},
                new CatlPart{PartName="Omega Vers. C",  Price=55.30M},
                new CatlPart{PartName="Beta Vers. A",   Price=25.90M},
                new CatlPart{PartName="Beta Vers. B",   Price=29.90M},
                new CatlPart{PartName="Beta Vers. XX",   Price=35M},
                new CatlPart{PartName="Alpha Vers. A",  Price=40.50M},
                new CatlPart{PartName="Alpha Vers. B",  Price=44.50M},
            };
            cParts.ForEach(s => context.CatlParts.Add(s));
            context.SaveChanges();
        }
    }
}
