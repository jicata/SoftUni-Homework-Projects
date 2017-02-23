namespace Shouter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDontKnowWhatHasChanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        PostedOn = c.DateTime(),
                        Lifetime = c.Int(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shouts", "Author_Id", "dbo.Users");
            DropIndex("dbo.Shouts", new[] { "Author_Id" });
            DropTable("dbo.Shouts");
        }
    }
}
