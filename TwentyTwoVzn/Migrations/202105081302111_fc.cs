namespace TwentyTwoVzn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Business_BusID", "dbo.Businesses");
            DropIndex("dbo.Events", new[] { "Business_BusID" });
            RenameColumn(table: "dbo.Events", name: "Business_BusID", newName: "BusID");
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AlterColumn("dbo.Events", "BusID", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "BusID");
            AddForeignKey("dbo.Events", "BusID", "dbo.Businesses", "BusID", cascadeDelete: true);
            DropColumn("dbo.Events", "BusinessID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "BusinessID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Events", "BusID", "dbo.Businesses");
            DropIndex("dbo.Events", new[] { "BusID" });
            AlterColumn("dbo.Events", "BusID", c => c.Int());
            DropColumn("dbo.AspNetUsers", "Address");
            RenameColumn(table: "dbo.Events", name: "BusID", newName: "Business_BusID");
            CreateIndex("dbo.Events", "Business_BusID");
            AddForeignKey("dbo.Events", "Business_BusID", "dbo.Businesses", "BusID");
        }
    }
}
