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

            List<Customer> customers = new List<Customer>
            {
                new Customer{FirstName="Julia", LastName="Dekker"},
                new Customer{FirstName="Bob", LastName="Dekker"},
                new Customer{FirstName="Jan", LastName="Jansen"},
                new Customer{FirstName="Klaas", LastName="van de Berg"},
                new Customer{FirstName="Linda", LastName="Bakker"},
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

            List<Part> parts = new List<Part>
            {
                new Part{PartName="Omega A", PartStatus=PartStatus.InStock, Price=59.20M},
                new Part{PartName="Omega A", PartStatus=PartStatus.Reserved, Price=59.20M},
                new Part{PartName="Omega C", PartStatus=PartStatus.AwaitingArrival, Price=55.30M},
                new Part{PartName="Beta A", PartStatus=PartStatus.InStock, Price=25.90M},
                new Part{PartName="Alpha A", PartStatus=PartStatus.AwaitingArrival, Price=40.50M},
            };
            parts.ForEach(s => context.Parts.Add(s));
            context.SaveChanges();
        }
    }
}
