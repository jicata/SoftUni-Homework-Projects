namespace SharpStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedEnumFromBuyer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buyers", "DeliveryType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buyers", "DeliveryType", c => c.Int(nullable: false));
        }
    }
}
