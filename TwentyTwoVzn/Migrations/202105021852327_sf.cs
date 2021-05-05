namespace TwentyTwoVzn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Businesses", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Businesses", "UserId");
        }
    }
}
