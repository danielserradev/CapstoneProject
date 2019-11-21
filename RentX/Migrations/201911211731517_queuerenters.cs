namespace RentX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class queuerenters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QueueRenters",
                c => new
                    {
                        QueueRenterId = c.Int(nullable: false, identity: true),
                        QueueId = c.Int(nullable: false),
                        RenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QueueRenterId)
                .ForeignKey("dbo.Queues", t => t.QueueId, cascadeDelete: true)
                .ForeignKey("dbo.Renters", t => t.RenterId, cascadeDelete: true)
                .Index(t => t.QueueId)
                .Index(t => t.RenterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QueueRenters", "RenterId", "dbo.Renters");
            DropForeignKey("dbo.QueueRenters", "QueueId", "dbo.Queues");
            DropIndex("dbo.QueueRenters", new[] { "RenterId" });
            DropIndex("dbo.QueueRenters", new[] { "QueueId" });
            DropTable("dbo.QueueRenters");
        }
    }
}
