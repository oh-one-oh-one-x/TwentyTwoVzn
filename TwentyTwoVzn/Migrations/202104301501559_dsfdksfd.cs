namespace TwentyTwoVzn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsfdksfd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Services", "ReviewID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "ReviewID", c => c.Int(nullable: false));
        }
    }
}
