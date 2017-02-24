namespace Shouter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shouts", "Lifetime", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shouts", "Lifetime", c => c.Time(nullable: false, precision: 7));
        }
    }
}
