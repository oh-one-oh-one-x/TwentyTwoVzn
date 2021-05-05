namespace TwentyTwoVzn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfkgnkfgfg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Image", c => c.Binary(nullable: false));
        }
    }
}
