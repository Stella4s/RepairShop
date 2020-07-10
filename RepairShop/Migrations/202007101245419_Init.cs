namespace RepairShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CatlPart",
                c => new
                    {
                        CatlPartId = c.Int(nullable: false, identity: true),
                        PartName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CatlPartId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        Customer_ID = c.Int(),
                        Technician_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.Customer_ID)
                .ForeignKey("dbo.Technician", t => t.Technician_ID)
                .Index(t => t.Customer_ID)
                .Index(t => t.Technician_ID);
            
            CreateTable(
                "dbo.StockPart",
                c => new
                    {
                        StockPartId = c.Int(nullable: false, identity: true),
                        PartStatus = c.Int(nullable: false),
                        Part_CatlPartId = c.Int(),
                        RepairOrder_ID = c.Int(),
                    })
                .PrimaryKey(t => t.StockPartId)
                .ForeignKey("dbo.CatlPart", t => t.Part_CatlPartId)
                .ForeignKey("dbo.RepairOrder", t => t.RepairOrder_ID)
                .Index(t => t.Part_CatlPartId)
                .Index(t => t.RepairOrder_ID);
            
            CreateTable(
                "dbo.Technician",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HourPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RepairOrder", "Technician_ID", "dbo.Technician");
            DropForeignKey("dbo.StockPart", "RepairOrder_ID", "dbo.RepairOrder");
            DropForeignKey("dbo.StockPart", "Part_CatlPartId", "dbo.CatlPart");
            DropForeignKey("dbo.RepairOrder", "Customer_ID", "dbo.Customer");
            DropIndex("dbo.StockPart", new[] { "RepairOrder_ID" });
            DropIndex("dbo.StockPart", new[] { "Part_CatlPartId" });
            DropIndex("dbo.RepairOrder", new[] { "Technician_ID" });
            DropIndex("dbo.RepairOrder", new[] { "Customer_ID" });
            DropTable("dbo.Technician");
            DropTable("dbo.StockPart");
            DropTable("dbo.RepairOrder");
            DropTable("dbo.Customer");
            DropTable("dbo.CatlPart");
        }
    }
}
