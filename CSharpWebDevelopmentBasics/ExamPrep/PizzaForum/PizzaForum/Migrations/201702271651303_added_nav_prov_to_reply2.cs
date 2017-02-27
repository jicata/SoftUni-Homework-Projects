namespace PizzaForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_nav_prov_to_reply2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replies", "Topic_Id", "dbo.Topics");
            DropIndex("dbo.Replies", new[] { "Topic_Id" });
            RenameColumn(table: "dbo.Replies", name: "Topic_Id", newName: "TopicId");
            AlterColumn("dbo.Replies", "TopicId", c => c.Int(nullable: false));
            CreateIndex("dbo.Replies", "TopicId");
            AddForeignKey("dbo.Replies", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "TopicId", "dbo.Topics");
            DropIndex("dbo.Replies", new[] { "TopicId" });
            AlterColumn("dbo.Replies", "TopicId", c => c.Int());
            RenameColumn(table: "dbo.Replies", name: "TopicId", newName: "Topic_Id");
            CreateIndex("dbo.Replies", "Topic_Id");
            AddForeignKey("dbo.Replies", "Topic_Id", "dbo.Topics", "Id");
        }
    }
}
