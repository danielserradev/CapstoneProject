namespace RentX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullfk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "RenterId", "dbo.Renters");
            DropIndex("dbo.Items", new[] { "RenterId" });
            AlterColumn("dbo.Items", "RenterId", c => c.Int());
            CreateIndex("dbo.Items", "RenterId");
            AddForeignKey("dbo.Items", "RenterId", "dbo.Renters", "RenterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "RenterId", "dbo.Renters");
            DropIndex("dbo.Items", new[] { "RenterId" });
            AlterColumn("dbo.Items", "RenterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "RenterId");
            AddForeignKey("dbo.Items", "RenterId", "dbo.Renters", "RenterId", cascadeDelete: true);
        }
    }
}
