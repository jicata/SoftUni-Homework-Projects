namespace _02.CreateUser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "RegisteredOn", c => c.DateTime());
            AlterColumn("dbo.Users", "LastTimeLoggedIn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "LastTimeLoggedIn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "RegisteredOn", c => c.DateTime(nullable: false));
        }
    }
}
