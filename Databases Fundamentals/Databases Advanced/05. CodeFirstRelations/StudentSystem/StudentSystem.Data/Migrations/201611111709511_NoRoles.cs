namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoRoles : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StudentAlbums", "StudentRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentAlbums", "StudentRole", c => c.Int(nullable: false));
        }
    }
}
