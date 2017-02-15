namespace SimpleMVC.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notes", "User_Id", "dbo.Users");
            DropIndex("dbo.Notes", new[] { "User_Id" });
            RenameColumn(table: "dbo.Notes", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Notes", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Notes", "UserId");
            AddForeignKey("dbo.Notes", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "UserId", "dbo.Users");
            DropIndex("dbo.Notes", new[] { "UserId" });
            AlterColumn("dbo.Notes", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Notes", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Notes", "User_Id");
            AddForeignKey("dbo.Notes", "User_Id", "dbo.Users", "Id");
        }
    }
}
