namespace SimpleMVC.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class includedIdentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        Session_Id = c.String(maxLength: 128),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HttpSessions", t => t.Session_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Session_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.HttpSessions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Logins", "Session_Id", "dbo.HttpSessions");
            DropIndex("dbo.Logins", new[] { "User_Id" });
            DropIndex("dbo.Logins", new[] { "Session_Id" });
            DropTable("dbo.HttpSessions");
            DropTable("dbo.Logins");
        }
    }
}
