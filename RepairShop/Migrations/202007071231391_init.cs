namespace RepairShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Part",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        PartName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PartStatus = c.Int(nullable: false),
                        RepairOrder_ID = c.Int(),
                    })
                .PrimaryKey(t => t.PartId)
                .ForeignKey("dbo.RepairOrder", t => t.RepairOrder_ID)
                .Index(t => t.RepairOrder_ID);
            
            CreateTable(
                "dbo.RepairOrder",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RepairStatus = c.Int(nullable: false),
                        HoursWorkedOn = c.Int(),
                        Description = c.String(),
                        IsLate = c.Boolean(nullable: false),
                        Customer_CustomerId = c.Int(),
                        Technician_TechnicianId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.Customer_CustomerId)
                .ForeignKey("dbo.Technician", t => t.Technician_TechnicianId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.Technician_TechnicianId);
            
            CreateTable(
                "dbo.Technician",
                c => new
                    {
                        TechnicianId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        HourPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TechnicianId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RepairOrder", "Technician_TechnicianId", "dbo.Technician");
            DropForeignKey("dbo.Part", "RepairOrder_ID", "dbo.RepairOrder");
            DropForeignKey("dbo.RepairOrder", "Customer_CustomerId", "dbo.Customer");
            DropIndex("dbo.RepairOrder", new[] { "Technician_TechnicianId" });
            DropIndex("dbo.RepairOrder", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Part", new[] { "RepairOrder_ID" });
            DropTable("dbo.Technician");
            DropTable("dbo.RepairOrder");
            DropTable("dbo.Part");
            DropTable("dbo.Customer");
        }
    }
}
