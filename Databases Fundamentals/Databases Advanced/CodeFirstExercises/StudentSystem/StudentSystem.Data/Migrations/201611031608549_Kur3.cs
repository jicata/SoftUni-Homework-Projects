namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kur3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Homework", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Homework", new[] { "Course_Id" });
            RenameColumn(table: "dbo.Homework", name: "Course_Id", newName: "CourseId");
            AlterColumn("dbo.Homework", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Homework", "CourseId");
            AddForeignKey("dbo.Homework", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homework", "CourseId", "dbo.Courses");
            DropIndex("dbo.Homework", new[] { "CourseId" });
            AlterColumn("dbo.Homework", "CourseId", c => c.Int());
            RenameColumn(table: "dbo.Homework", name: "CourseId", newName: "Course_Id");
            CreateIndex("dbo.Homework", "Course_Id");
            AddForeignKey("dbo.Homework", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
