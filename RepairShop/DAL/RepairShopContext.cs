using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RepairShop.Models;

namespace RepairShop.DAL
{
    public class RepairShopContext : DbContext
    {
        public RepairShopContext() : base("DefaultConnection")
        {
        }

        public DbSet<RepairOrder> RepairOrders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Technician> Technicians { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}