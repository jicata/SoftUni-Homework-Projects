namespace MassDefect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anomalies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginPlanet_Id = c.Int(),
                        TeleportPlanet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Planets", t => t.OriginPlanet_Id)
                .ForeignKey("dbo.Planets", t => t.TeleportPlanet_Id)
                .Index(t => t.OriginPlanet_Id)
                .Index(t => t.TeleportPlanet_Id);
            
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SunId = c.Int(nullable: false),
                        SolarSystem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SolarSystems", t => t.SolarSystem_Id)
                .ForeignKey("dbo.Stars", t => t.SunId, cascadeDelete: true)
                .Index(t => t.SunId)
                .Index(t => t.SolarSystem_Id);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        HomePlanetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Planets", t => t.HomePlanetId, cascadeDelete: true)
                .Index(t => t.HomePlanetId);
            
            CreateTable(
                "dbo.SolarSystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SolarSystem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SolarSystems", t => t.SolarSystem_Id)
                .Index(t => t.SolarSystem_Id);
            
            CreateTable(
                "dbo.PersonAnomalies",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Anomaly_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Anomaly_Id })
                .ForeignKey("dbo.Persons", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Anomalies", t => t.Anomaly_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Anomaly_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anomalies", "TeleportPlanet_Id", "dbo.Planets");
            DropForeignKey("dbo.Anomalies", "OriginPlanet_Id", "dbo.Planets");
            DropForeignKey("dbo.Planets", "SunId", "dbo.Stars");
            DropForeignKey("dbo.Stars", "SolarSystem_Id", "dbo.SolarSystems");
            DropForeignKey("dbo.Planets", "SolarSystem_Id", "dbo.SolarSystems");
            DropForeignKey("dbo.Persons", "HomePlanetId", "dbo.Planets");
            DropForeignKey("dbo.PersonAnomalies", "Anomaly_Id", "dbo.Anomalies");
            DropForeignKey("dbo.PersonAnomalies", "Person_Id", "dbo.Persons");
            DropIndex("dbo.PersonAnomalies", new[] { "Anomaly_Id" });
            DropIndex("dbo.PersonAnomalies", new[] { "Person_Id" });
            DropIndex("dbo.Stars", new[] { "SolarSystem_Id" });
            DropIndex("dbo.Persons", new[] { "HomePlanetId" });
            DropIndex("dbo.Planets", new[] { "SolarSystem_Id" });
            DropIndex("dbo.Planets", new[] { "SunId" });
            DropIndex("dbo.Anomalies", new[] { "TeleportPlanet_Id" });
            DropIndex("dbo.Anomalies", new[] { "OriginPlanet_Id" });
            DropTable("dbo.PersonAnomalies");
            DropTable("dbo.Stars");
            DropTable("dbo.SolarSystems");
            DropTable("dbo.Persons");
            DropTable("dbo.Planets");
            DropTable("dbo.Anomalies");
        }
    }
}
