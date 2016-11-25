namespace MassDefect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnomaliesVictims : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AnomalyVictims", newName: "AnomaliesVictims");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AnomaliesVictims", newName: "AnomalyVictims");
        }
    }
}
