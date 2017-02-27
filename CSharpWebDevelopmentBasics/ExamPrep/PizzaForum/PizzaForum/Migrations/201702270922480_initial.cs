namespace PizzaForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 450),
                        Email = c.String(maxLength: 450),
                        Password = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Email, unique: true, name: "Email");
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        PublishDate = c.DateTime(),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        PublishDate = c.DateTime(),
                        ImageUrl = c.String(),
                        Author_Id = c.Int(),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Topic_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Replies", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Replies", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Topics", "Author_Id", "dbo.Users");
            DropIndex("dbo.Replies", new[] { "Topic_Id" });
            DropIndex("dbo.Replies", new[] { "Author_Id" });
            DropIndex("dbo.Topics", new[] { "Author_Id" });
            DropIndex("dbo.Users", "Email");
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Logins", new[] { "User_Id" });
            DropTable("dbo.Replies");
            DropTable("dbo.Topics");
            DropTable("dbo.Users");
            DropTable("dbo.Logins");
        }
    }
}
