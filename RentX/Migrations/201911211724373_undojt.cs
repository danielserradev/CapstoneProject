namespace RentX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class undojt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QueueRenters", "Queue_QueueId", "dbo.Queues");
            DropForeignKey("dbo.QueueRenters", "Renter_RenterId", "dbo.Renters");
            DropIndex("dbo.QueueRenters", new[] { "Queue_QueueId" });
            DropIndex("dbo.QueueRenters", new[] { "Renter_RenterId" });
            DropTable("dbo.QueueRenters");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QueueRenters",
                c => new
                    {
                        Queue_QueueId = c.Int(nullable: false),
                        Renter_RenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Queue_QueueId, t.Renter_RenterId });
            
            CreateIndex("dbo.QueueRenters", "Renter_RenterId");
            CreateIndex("dbo.QueueRenters", "Queue_QueueId");
            AddForeignKey("dbo.QueueRenters", "Renter_RenterId", "dbo.Renters", "RenterId", cascadeDelete: true);
            AddForeignKey("dbo.QueueRenters", "Queue_QueueId", "dbo.Queues", "QueueId", cascadeDelete: true);
        }
    }
}
