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
                new RepairOrder{
                    StartDate =DateTime.Parse("06-07-2020"),
                    EndDate =DateTime.Parse("19-07-2020"),
                    RepairStatus =RepairStatus.Finished,
                    Customer = context.Customers.FirstOrDefault( c => c.FirstName == "Julia"),
                    Technician = context.Technicians.FirstOrDefault( c => c.FirstName == "Daan")
                },
                new RepairOrder{StartDate=DateTime.Parse("04-07-2020"), EndDate=DateTime.Parse("20-07-2020"), RepairStatus=RepairStatus.Awaiting,
                    Customer = context.Customers.FirstOrDefault( c => c.FirstName == "Bob"),
                    Technician = context.Technicians.FirstOrDefault( c => c.FirstName == "Henk")
                },
                new RepairOrder{StartDate=DateTime.Parse("12-07-2020"), EndDate=DateTime.Parse("19-07-2020"), RepairStatus=RepairStatus.InProgress ,
                    Customer = context.Customers.FirstOrDefault( c => c.FirstName == "Bob"),
                    Technician = context.Technicians.FirstOrDefault( c => c.FirstName == "Daan")
                },
                new RepairOrder{StartDate=DateTime.Parse("20-07-2020"), EndDate=DateTime.Parse("29-07-2020"), RepairStatus=RepairStatus.Awaiting,
                    Customer = context.Customers.FirstOrDefault( c => c.FirstName == "Jan"),
                    Technician = context.Technicians.FirstOrDefault( c => c.FirstName == "Nienke")
                },
                new RepairOrder{StartDate=DateTime.Parse("29-08-2020"), EndDate=DateTime.Parse("29-07-2020"), RepairStatus=RepairStatus.Awaiting,
                    Customer = context.Customers.FirstOrDefault( c => c.FirstName == "Klaas"),
                    Technician = context.Technicians.FirstOrDefault( c => c.FirstName == "Nienke")
                },
                new RepairOrder{StartDate=DateTime.Parse("20-07-2020"), EndDate=DateTime.Parse("29-07-2020"), RepairStatus=RepairStatus.AwaitingParts,
                    Customer = context.Customers.FirstOrDefault( c => c.FirstName == "Linda"),
                    Technician = context.Technicians.FirstOrDefault( c => c.FirstName == "Martijn")
                },
            };
            repairOrders.ForEach(s => context.RepairOrders.Add(s));
            context.SaveChanges();

            List<CatlPart> cParts = new List<CatlPart>
            {
                new CatlPart{PartName="Omega A",  Price=59.20M},
                new CatlPart{PartName="Omega B",  Price=60M},
                new CatlPart{PartName="Omega C",  Price=55.30M},
                new CatlPart{PartName="Beta A",   Price=25.90M},
                new CatlPart{PartName="Beta B",   Price=29.90M},
                new CatlPart{PartName="Beta XX",  Price=35M},
                new CatlPart{PartName="Alpha A",  Price=40.50M},
                new CatlPart{PartName="Alpha B",  Price=44.50M},
            };
            cParts.ForEach(s => context.CatlParts.Add(s));
            context.SaveChanges();

            List<StockPart> sParts = new List<StockPart>
            {
                new StockPart{ PartStatus= PartStatus.AwaitingArrival, Part = context.CatlParts.FirstOrDefault(c => c.PartName == "Omega A")},
                new StockPart{ PartStatus= PartStatus.AwaitingArrival, Part = context.CatlParts.FirstOrDefault(c => c.PartName == "Omega A")},
                new StockPart{ PartStatus= PartStatus.Reserved,        Part = context.CatlParts.FirstOrDefault(c => c.PartName == "Omega A")},
                new StockPart{ PartStatus= PartStatus.InStock,         Part = context.CatlParts.FirstOrDefault(c => c.PartName == "Omega B")},
                new StockPart{ PartStatus= PartStatus.AwaitingArrival, Part = context.CatlParts.FirstOrDefault(c => c.PartName == "Beta A")},
                new StockPart{ PartStatus= PartStatus.AwaitingArrival, Part = context.CatlParts.FirstOrDefault(c => c.PartName == "Beta XX")},
                new StockPart{ PartStatus= PartStatus.Reserved,        Part = context.CatlParts.FirstOrDefault(c => c.PartName == "Alpha A")},
                new StockPart{ PartStatus= PartStatus.InStock,         Part = context.CatlParts.FirstOrDefault(c => c.PartName == "Alpha B")},
            };
            sParts.ForEach(s => context.StockParts.Add(s));
            context.SaveChanges();

        }
    }
}
