namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YesRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentAlbums", "StudentRole", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentAlbums", "StudentRole");
        }
    }
}
