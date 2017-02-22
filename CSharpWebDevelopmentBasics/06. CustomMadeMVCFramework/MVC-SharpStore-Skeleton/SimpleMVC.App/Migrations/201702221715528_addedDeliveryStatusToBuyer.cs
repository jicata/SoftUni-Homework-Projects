namespace SharpStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDeliveryStatusToBuyer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyers", "DeliveryStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyers", "DeliveryStatus");
        }
    }
}
