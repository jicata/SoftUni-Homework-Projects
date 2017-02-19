namespace SimpleMVC.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loginImproved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logins", "Session_Id", "dbo.HttpSessions");
            DropIndex("dbo.Logins", new[] { "Session_Id" });
            AddColumn("dbo.Logins", "SessionId", c => c.String());
            DropColumn("dbo.Logins", "Session_Id");
            DropTable("dbo.HttpSessions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HttpSessions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Logins", "Session_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Logins", "SessionId");
            CreateIndex("dbo.Logins", "Session_Id");
            AddForeignKey("dbo.Logins", "Session_Id", "dbo.HttpSessions", "Id");
        }
    }
}
