namespace RentX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removepropfromtrans : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transactions", "DayofPayment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "DayofPayment", c => c.DateTime());
        }
    }
}
