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
                        CustomerID = c.Int(nullable: false),
                        TechnicianID = c.Int(nullable: false),
                        HoursWorkedOn = c.Int(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Technician", t => t.TechnicianID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.TechnicianID);
            
            CreateTable(
                "dbo.StockPart",
                c => new
                    {
                        StockPartID = c.Int(nullable: false, identity: true),
                        CatlPartID = c.Int(nullable: false),
                        PartStatus = c.Int(nullable: false),
                        RepairOrder_ID = c.Int(),
                    })
                .PrimaryKey(t => t.StockPartID)
                .ForeignKey("dbo.CatlPart", t => t.CatlPartID, cascadeDelete: true)
                .ForeignKey("dbo.RepairOrder", t => t.RepairOrder_ID)
                .Index(t => t.CatlPartID)
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
            DropForeignKey("dbo.RepairOrder", "TechnicianID", "dbo.Technician");
            DropForeignKey("dbo.StockPart", "RepairOrder_ID", "dbo.RepairOrder");
            DropForeignKey("dbo.StockPart", "CatlPartID", "dbo.CatlPart");
            DropForeignKey("dbo.RepairOrder", "CustomerID", "dbo.Customer");
            DropIndex("dbo.StockPart", new[] { "RepairOrder_ID" });
            DropIndex("dbo.StockPart", new[] { "CatlPartID" });
            DropIndex("dbo.RepairOrder", new[] { "TechnicianID" });
            DropIndex("dbo.RepairOrder", new[] { "CustomerID" });
            DropTable("dbo.Technician");
            DropTable("dbo.StockPart");
            DropTable("dbo.RepairOrder");
            DropTable("dbo.Customer");
            DropTable("dbo.CatlPart");
        }
    }
}
