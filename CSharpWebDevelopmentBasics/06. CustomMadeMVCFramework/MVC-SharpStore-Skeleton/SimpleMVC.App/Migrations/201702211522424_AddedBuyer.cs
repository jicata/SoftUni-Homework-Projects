namespace SharpStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBuyer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        DeliveryType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.Buyers");
        }
    }
}
