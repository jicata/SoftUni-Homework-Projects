namespace Shouter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class navProptToNotifications : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notifications", "ShoutAuthor_Id", "dbo.Users");
            AddColumn("dbo.Users", "Notification_Id", c => c.Int());
            AddColumn("dbo.Notifications", "User_Id", c => c.Int());
            CreateIndex("dbo.Users", "Notification_Id");
            CreateIndex("dbo.Notifications", "User_Id");
            AddForeignKey("dbo.Users", "Notification_Id", "dbo.Notifications", "Id");
            AddForeignKey("dbo.Notifications", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Notification_Id", "dbo.Notifications");
            DropIndex("dbo.Notifications", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Notification_Id" });
            DropColumn("dbo.Notifications", "User_Id");
            DropColumn("dbo.Users", "Notification_Id");
            AddForeignKey("dbo.Notifications", "ShoutAuthor_Id", "dbo.Users", "Id");
        }
    }
}
