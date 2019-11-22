namespace RentX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phonenumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leasors", "PhoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.Renters", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Renters", "PhoneNumber");
            DropColumn("dbo.Leasors", "PhoneNumber");
        }
    }
}
