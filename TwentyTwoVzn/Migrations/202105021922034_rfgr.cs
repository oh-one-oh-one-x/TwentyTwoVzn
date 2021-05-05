namespace TwentyTwoVzn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rfgr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ServiceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "ServiceID");
            AddForeignKey("dbo.Items", "ServiceID", "dbo.Services", "ServiceID", cascadeDelete: true);
            DropColumn("dbo.Items", "ItemOrder");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "ItemOrder", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Items", "ServiceID", "dbo.Services");
            DropIndex("dbo.Items", new[] { "ServiceID" });
            DropColumn("dbo.Items", "ServiceID");
        }
    }
}
