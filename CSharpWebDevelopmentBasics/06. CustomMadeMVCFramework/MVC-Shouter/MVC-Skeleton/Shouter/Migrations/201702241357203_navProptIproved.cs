namespace Shouter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class navProptIproved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Notification_Id", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Notification_Id" });
            DropIndex("dbo.Notifications", new[] { "User_Id" });
            CreateTable(
                "dbo.NotificationUsers",
                c => new
                    {
                        Notification_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Notification_Id, t.User_Id })
                .ForeignKey("dbo.Notifications", t => t.Notification_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Notification_Id)
                .Index(t => t.User_Id);
            
            DropColumn("dbo.Users", "Notification_Id");
            DropColumn("dbo.Notifications", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "User_Id", c => c.Int());
            AddColumn("dbo.Users", "Notification_Id", c => c.Int());
            DropForeignKey("dbo.NotificationUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.NotificationUsers", "Notification_Id", "dbo.Notifications");
            DropIndex("dbo.NotificationUsers", new[] { "User_Id" });
            DropIndex("dbo.NotificationUsers", new[] { "Notification_Id" });
            DropTable("dbo.NotificationUsers");
            CreateIndex("dbo.Notifications", "User_Id");
            CreateIndex("dbo.Users", "Notification_Id");
            AddForeignKey("dbo.Notifications", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Notification_Id", "dbo.Notifications", "Id");
        }
    }
}
