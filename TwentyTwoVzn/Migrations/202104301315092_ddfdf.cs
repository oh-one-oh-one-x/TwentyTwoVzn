namespace TwentyTwoVzn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddfdf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        BusID = c.Int(nullable: false, identity: true),
                        BusName = c.String(),
                        BusLocation = c.String(),
                        BusContact = c.Int(nullable: false),
                        BusOwner = c.String(),
                        BusInfo = c.String(),
                    })
                .PrimaryKey(t => t.BusID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        Host = c.String(),
                        EventFee = c.Double(nullable: false),
                        EventCapacity = c.Int(nullable: false),
                        EventStatus = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.Int(nullable: false),
                        ItemImage = c.Binary(),
                        ItemPrice = c.Double(nullable: false),
                        ItemDetails = c.String(),
                        ItemOrder = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID);
            
            CreateTable(
                "dbo.Reserves",
                c => new
                    {
                        ReserveID = c.Int(nullable: false, identity: true),
                        NumAttendees = c.Int(nullable: false),
                        ReserveDate = c.DateTime(nullable: false),
                        EventID = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.ReserveID)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        ReviewDate = c.DateTime(nullable: false),
                        Rating = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Services", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.ServiceID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(nullable: false),
                        ServiceDetails = c.String(),
                        ServiceImage = c.Binary(),
                        ServiceLocation = c.String(),
                        ServiceTypeID = c.Int(nullable: false),
                        ReviewID = c.Int(nullable: false),
                        BusinessID = c.Int(nullable: false),
                        Business_BusID = c.Int(),
                        ServiceTypes_TypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.Businesses", t => t.Business_BusID)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypes_TypeID)
                .Index(t => t.Business_BusID)
                .Index(t => t.ServiceTypes_TypeID);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Services", "ServiceTypes_TypeID", "dbo.ServiceTypes");
            DropForeignKey("dbo.Reviews", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.Services", "Business_BusID", "dbo.Businesses");
            DropForeignKey("dbo.Reserves", "EventID", "dbo.Events");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Services", new[] { "ServiceTypes_TypeID" });
            DropIndex("dbo.Services", new[] { "Business_BusID" });
            DropIndex("dbo.Reviews", new[] { "ServiceID" });
            DropIndex("dbo.Reserves", new[] { "EventID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.Services");
            DropTable("dbo.Reviews");
            DropTable("dbo.Reserves");
            DropTable("dbo.Items");
            DropTable("dbo.Events");
            DropTable("dbo.Businesses");
        }
    }
}
