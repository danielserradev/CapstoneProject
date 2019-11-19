namespace RentX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        RentCounter = c.Int(),
                        Availability = c.Boolean(nullable: false),
                        NumOfMonthsForRent = c.Int(nullable: false),
                        DeliveryOption = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        LeasorId = c.Int(nullable: false),
                        RenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Leasors", t => t.LeasorId, cascadeDelete: true)
                .ForeignKey("dbo.Renters", t => t.RenterId, cascadeDelete: true)
                .Index(t => t.LeasorId)
                .Index(t => t.RenterId);
            
            CreateTable(
                "dbo.Leasors",
                c => new
                    {
                        LeasorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LasttName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        City = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        Lat = c.Single(nullable: false),
                        Lng = c.Single(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LeasorId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Renters",
                c => new
                    {
                        RenterId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LasttName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        City = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        Lat = c.Single(nullable: false),
                        Lng = c.Single(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RenterId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        NumOfStars = c.Int(nullable: false),
                        Review = c.String(),
                        LeasorId = c.Int(nullable: false),
                        RenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.Leasors", t => t.LeasorId, cascadeDelete: true)
                .ForeignKey("dbo.Renters", t => t.RenterId, cascadeDelete: true)
                .Index(t => t.LeasorId)
                .Index(t => t.RenterId);
            
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
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        TimeOfPayment = c.DateTime(),
                        DayofPayment = c.DateTime(),
                        LeasorId = c.Int(),
                        RenterId = c.Int(),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Leasors", t => t.LeasorId)
                .ForeignKey("dbo.Renters", t => t.RenterId)
                .Index(t => t.LeasorId)
                .Index(t => t.RenterId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "RenterId", "dbo.Renters");
            DropForeignKey("dbo.Transactions", "LeasorId", "dbo.Leasors");
            DropForeignKey("dbo.Transactions", "ItemId", "dbo.Items");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Ratings", "RenterId", "dbo.Renters");
            DropForeignKey("dbo.Ratings", "LeasorId", "dbo.Leasors");
            DropForeignKey("dbo.Items", "RenterId", "dbo.Renters");
            DropForeignKey("dbo.Renters", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Items", "LeasorId", "dbo.Leasors");
            DropForeignKey("dbo.Leasors", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Transactions", new[] { "ItemId" });
            DropIndex("dbo.Transactions", new[] { "RenterId" });
            DropIndex("dbo.Transactions", new[] { "LeasorId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Ratings", new[] { "RenterId" });
            DropIndex("dbo.Ratings", new[] { "LeasorId" });
            DropIndex("dbo.Renters", new[] { "ApplicationId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Leasors", new[] { "ApplicationId" });
            DropIndex("dbo.Items", new[] { "RenterId" });
            DropIndex("dbo.Items", new[] { "LeasorId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Ratings");
            DropTable("dbo.Renters");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Leasors");
            DropTable("dbo.Items");
        }
    }
}
