namespace TwentyTwoVzn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "ItemImage", c => c.Binary());
            AlterColumn("dbo.Services", "ServiceImage", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "ServiceImage", c => c.Binary(nullable: false));
            AlterColumn("dbo.Items", "ItemImage", c => c.Binary(nullable: false));
        }
    }
}
