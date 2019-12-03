namespace RentX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingqueue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RatingQueues",
                c => new
                    {
                        RatingQueueId = c.Int(nullable: false, identity: true),
                        LeasorId = c.Int(),
                        RenterId = c.Int(),
                    })
                .PrimaryKey(t => t.RatingQueueId)
                .ForeignKey("dbo.Leasors", t => t.LeasorId)
                .ForeignKey("dbo.Renters", t => t.RenterId)
                .Index(t => t.LeasorId)
                .Index(t => t.RenterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RatingQueues", "RenterId", "dbo.Renters");
            DropForeignKey("dbo.RatingQueues", "LeasorId", "dbo.Leasors");
            DropIndex("dbo.RatingQueues", new[] { "RenterId" });
            DropIndex("dbo.RatingQueues", new[] { "LeasorId" });
            DropTable("dbo.RatingQueues");
        }
    }
}
