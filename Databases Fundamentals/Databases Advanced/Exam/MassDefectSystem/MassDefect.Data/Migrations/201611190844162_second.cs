namespace MassDefect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PersonAnomalies", newName: "AnomalyVictims");
            RenameColumn(table: "dbo.AnomalyVictims", name: "Person_Id", newName: "AnomalyId");
            RenameColumn(table: "dbo.AnomalyVictims", name: "Anomaly_Id", newName: "PersonId");
            RenameIndex(table: "dbo.AnomalyVictims", name: "IX_Person_Id", newName: "IX_AnomalyId");
            RenameIndex(table: "dbo.AnomalyVictims", name: "IX_Anomaly_Id", newName: "IX_PersonId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AnomalyVictims", name: "IX_PersonId", newName: "IX_Anomaly_Id");
            RenameIndex(table: "dbo.AnomalyVictims", name: "IX_AnomalyId", newName: "IX_Person_Id");
            RenameColumn(table: "dbo.AnomalyVictims", name: "PersonId", newName: "Anomaly_Id");
            RenameColumn(table: "dbo.AnomalyVictims", name: "AnomalyId", newName: "Person_Id");
            RenameTable(name: "dbo.AnomalyVictims", newName: "PersonAnomalies");
        }
    }
}
