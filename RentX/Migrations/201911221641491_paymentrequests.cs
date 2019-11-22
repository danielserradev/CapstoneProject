namespace RentX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentrequests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentRequests",
                c => new
                    {
                        PaymentRequestId = c.Int(nullable: false, identity: true),
                        RenterId = c.Int(),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentRequestId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Renters", t => t.RenterId)
                .Index(t => t.RenterId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentRequests", "RenterId", "dbo.Renters");
            DropForeignKey("dbo.PaymentRequests", "ItemId", "dbo.Items");
            DropIndex("dbo.PaymentRequests", new[] { "ItemId" });
            DropIndex("dbo.PaymentRequests", new[] { "RenterId" });
            DropTable("dbo.PaymentRequests");
        }
    }
}
