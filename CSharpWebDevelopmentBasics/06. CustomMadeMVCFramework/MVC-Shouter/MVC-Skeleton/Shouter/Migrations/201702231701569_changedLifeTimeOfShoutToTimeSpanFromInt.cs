namespace Shouter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedLifeTimeOfShoutToTimeSpanFromInt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Shouts","Lifetime");
            AddColumn("dbo.Shouts", "Lifetime", c=>c.Time(nullable:true,precision:7));
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shouts", "Lifetime", c => c.Int(nullable: false));
        }
    }
}
