namespace TwentyTwoVzn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xced : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "BusinessID", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "EventName", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Host", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "ItemName", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "ItemImage", c => c.Binary(nullable: false));
            AlterColumn("dbo.Items", "ItemDetails", c => c.String(nullable: false));
            AlterColumn("dbo.Reviews", "Comment", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "ServiceDetails", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "ServiceImage", c => c.Binary(nullable: false));
            AlterColumn("dbo.Services", "ServiceLocation", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceTypes", "TypeName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceTypes", "TypeName", c => c.String());
            AlterColumn("dbo.Services", "ServiceLocation", c => c.String());
            AlterColumn("dbo.Services", "ServiceImage", c => c.Binary());
            AlterColumn("dbo.Services", "ServiceDetails", c => c.String());
            AlterColumn("dbo.Reviews", "Comment", c => c.String());
            AlterColumn("dbo.Items", "ItemDetails", c => c.String());
            AlterColumn("dbo.Items", "ItemImage", c => c.Binary());
            AlterColumn("dbo.Items", "ItemName", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "Location", c => c.String());
            AlterColumn("dbo.Events", "Host", c => c.String());
            AlterColumn("dbo.Events", "EventName", c => c.String());
            DropColumn("dbo.Events", "BusinessID");
        }
    }
}
