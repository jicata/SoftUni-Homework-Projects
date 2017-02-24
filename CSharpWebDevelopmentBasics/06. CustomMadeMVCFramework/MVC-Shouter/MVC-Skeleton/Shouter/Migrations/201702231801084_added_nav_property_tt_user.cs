namespace Shouter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_nav_property_tt_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "User_Id", c => c.Int());
            CreateIndex("dbo.Users", "User_Id");
            AddForeignKey("dbo.Users", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_Id" });
            DropColumn("dbo.Users", "User_Id");
        }
    }
}
