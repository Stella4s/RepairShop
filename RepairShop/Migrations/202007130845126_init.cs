namespace RepairShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RepairOrder", "HoursWorkedOn", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RepairOrder", "HoursWorkedOn", c => c.Int());
        }
    }
}
