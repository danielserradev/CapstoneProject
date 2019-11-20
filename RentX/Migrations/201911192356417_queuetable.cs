namespace RentX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class queuetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Queues",
                c => new
                    {
                        QueueId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(),
                    })
                .PrimaryKey(t => t.QueueId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ItemId);
            
            AddColumn("dbo.Leasors", "StateCode", c => c.String(nullable: false));
            AddColumn("dbo.Renters", "StateCode", c => c.String(nullable: false));
            AddColumn("dbo.Renters", "Queue_QueueId", c => c.Int());
            CreateIndex("dbo.Renters", "Queue_QueueId");
            AddForeignKey("dbo.Renters", "Queue_QueueId", "dbo.Queues", "QueueId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Renters", "Queue_QueueId", "dbo.Queues");
            DropForeignKey("dbo.Queues", "ItemId", "dbo.Items");
            DropIndex("dbo.Queues", new[] { "ItemId" });
            DropIndex("dbo.Renters", new[] { "Queue_QueueId" });
            DropColumn("dbo.Renters", "Queue_QueueId");
            DropColumn("dbo.Renters", "StateCode");
            DropColumn("dbo.Leasors", "StateCode");
            DropTable("dbo.Queues");
        }
    }
}
