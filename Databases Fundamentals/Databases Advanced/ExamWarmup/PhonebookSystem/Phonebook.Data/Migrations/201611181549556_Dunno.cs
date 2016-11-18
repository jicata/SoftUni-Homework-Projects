namespace Phonebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dunno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Site", c => c.String());
            DropColumn("dbo.Contacts", "Url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Url", c => c.String());
            DropColumn("dbo.Contacts", "Site");
        }
    }
}
