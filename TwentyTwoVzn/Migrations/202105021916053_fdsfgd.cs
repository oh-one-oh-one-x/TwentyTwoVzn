namespace TwentyTwoVzn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fdsfgd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "ServiceTypes_TypeID", "dbo.ServiceTypes");
            DropIndex("dbo.Services", new[] { "ServiceTypes_TypeID" });
            RenameColumn(table: "dbo.Services", name: "ServiceTypes_TypeID", newName: "TypeID");
            AlterColumn("dbo.Services", "TypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Services", "TypeID");
            AddForeignKey("dbo.Services", "TypeID", "dbo.ServiceTypes", "TypeID", cascadeDelete: true);
            DropColumn("dbo.Services", "ServiceTypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "ServiceTypeID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Services", "TypeID", "dbo.ServiceTypes");
            DropIndex("dbo.Services", new[] { "TypeID" });
            AlterColumn("dbo.Services", "TypeID", c => c.Int());
            RenameColumn(table: "dbo.Services", name: "TypeID", newName: "ServiceTypes_TypeID");
            CreateIndex("dbo.Services", "ServiceTypes_TypeID");
            AddForeignKey("dbo.Services", "ServiceTypes_TypeID", "dbo.ServiceTypes", "TypeID");
        }
    }
}
