namespace TwentyTwoVzn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class csdfcds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Business_BusID", c => c.Int());
            AlterColumn("dbo.Businesses", "BusName", c => c.String(nullable: false));
            AlterColumn("dbo.Businesses", "BusLocation", c => c.String(nullable: false));
            AlterColumn("dbo.Businesses", "BusOwner", c => c.String(nullable: false));
            AlterColumn("dbo.Businesses", "BusInfo", c => c.String(nullable: false));
            CreateIndex("dbo.Events", "Business_BusID");
            AddForeignKey("dbo.Events", "Business_BusID", "dbo.Businesses", "BusID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Business_BusID", "dbo.Businesses");
            DropIndex("dbo.Events", new[] { "Business_BusID" });
            AlterColumn("dbo.Businesses", "BusInfo", c => c.String());
            AlterColumn("dbo.Businesses", "BusOwner", c => c.String());
            AlterColumn("dbo.Businesses", "BusLocation", c => c.String());
            AlterColumn("dbo.Businesses", "BusName", c => c.String());
            DropColumn("dbo.Events", "Business_BusID");
        }
    }
}
