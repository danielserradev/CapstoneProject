namespace RentX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class queuelist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Renters", "Queue_QueueId", "dbo.Queues");
            DropForeignKey("dbo.Ratings", "LeasorId", "dbo.Leasors");
            DropForeignKey("dbo.Ratings", "RenterId", "dbo.Renters");
            DropIndex("dbo.Renters", new[] { "Queue_QueueId" });
            DropIndex("dbo.Ratings", new[] { "LeasorId" });
            DropIndex("dbo.Ratings", new[] { "RenterId" });
            CreateTable(
                "dbo.QueueRenters",
                c => new
                    {
                        Queue_QueueId = c.Int(nullable: false),
                        Renter_RenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Queue_QueueId, t.Renter_RenterId })
                .ForeignKey("dbo.Queues", t => t.Queue_QueueId, cascadeDelete: true)
                .ForeignKey("dbo.Renters", t => t.Renter_RenterId, cascadeDelete: true)
                .Index(t => t.Queue_QueueId)
                .Index(t => t.Renter_RenterId);
            
            AlterColumn("dbo.Ratings", "LeasorId", c => c.Int());
            AlterColumn("dbo.Ratings", "RenterId", c => c.Int());
            CreateIndex("dbo.Ratings", "LeasorId");
            CreateIndex("dbo.Ratings", "RenterId");
            AddForeignKey("dbo.Ratings", "LeasorId", "dbo.Leasors", "LeasorId");
            AddForeignKey("dbo.Ratings", "RenterId", "dbo.Renters", "RenterId");
            DropColumn("dbo.Renters", "Queue_QueueId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Renters", "Queue_QueueId", c => c.Int());
            DropForeignKey("dbo.Ratings", "RenterId", "dbo.Renters");
            DropForeignKey("dbo.Ratings", "LeasorId", "dbo.Leasors");
            DropForeignKey("dbo.QueueRenters", "Renter_RenterId", "dbo.Renters");
            DropForeignKey("dbo.QueueRenters", "Queue_QueueId", "dbo.Queues");
            DropIndex("dbo.QueueRenters", new[] { "Renter_RenterId" });
            DropIndex("dbo.QueueRenters", new[] { "Queue_QueueId" });
            DropIndex("dbo.Ratings", new[] { "RenterId" });
            DropIndex("dbo.Ratings", new[] { "LeasorId" });
            AlterColumn("dbo.Ratings", "RenterId", c => c.Int(nullable: false));
            AlterColumn("dbo.Ratings", "LeasorId", c => c.Int(nullable: false));
            DropTable("dbo.QueueRenters");
            CreateIndex("dbo.Ratings", "RenterId");
            CreateIndex("dbo.Ratings", "LeasorId");
            CreateIndex("dbo.Renters", "Queue_QueueId");
            AddForeignKey("dbo.Ratings", "RenterId", "dbo.Renters", "RenterId", cascadeDelete: true);
            AddForeignKey("dbo.Ratings", "LeasorId", "dbo.Leasors", "LeasorId", cascadeDelete: true);
            AddForeignKey("dbo.Renters", "Queue_QueueId", "dbo.Queues", "QueueId");
        }
    }
}
