namespace TwentyTwoVzn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sfers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Image", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Image");
        }
    }
}
