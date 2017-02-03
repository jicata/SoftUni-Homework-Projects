namespace Products.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductType = c.Int(nullable: false),
                        PaymentDate = c.DateTime(),
                        DeliveryDate = c.DateTime(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Status_Id", "dbo.Status");
            DropIndex("dbo.Orders", new[] { "Status_Id" });
            DropTable("dbo.Status");
            DropTable("dbo.Orders");
        }
    }
}
