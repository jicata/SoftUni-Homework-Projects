namespace Shouter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNotifications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShoutAuthor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ShoutAuthor_Id)
                .Index(t => t.ShoutAuthor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "ShoutAuthor_Id", "dbo.Users");
            DropIndex("dbo.Notifications", new[] { "ShoutAuthor_Id" });
            DropTable("dbo.Notifications");
        }
    }
}
