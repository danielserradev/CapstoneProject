namespace RentX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkdeletion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "LeasorId", "dbo.Leasors");
            DropIndex("dbo.Transactions", new[] { "LeasorId" });
            DropColumn("dbo.Transactions", "LeasorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "LeasorId", c => c.Int());
            CreateIndex("dbo.Transactions", "LeasorId");
            AddForeignKey("dbo.Transactions", "LeasorId", "dbo.Leasors", "LeasorId");
        }
    }
}
