namespace VehicleSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carriages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PassangerSeatsCapacity = c.Int(nullable: false),
                        StandingPassangerCapacity = c.Int(),
                        TableCount = c.Int(),
                        BedCount = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Train_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trains", t => t.Train_Id)
                .Index(t => t.Train_Id);
            
            CreateTable(
                "dbo.Locomotives",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Model = c.String(),
                        Power = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trains", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        Model = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxSpeed = c.Double(nullable: false),
                        NumberOfEngines = c.Int(),
                        EngineType = c.String(),
                        TankCapacity = c.Decimal(precision: 18, scale: 2),
                        Discriminator = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trains",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NumberOfCarriages = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NumberOfDoors = c.Int(nullable: false),
                        IsInsured = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Planes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AirlineOwner = c.String(),
                        Color = c.String(),
                        PassangerCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nationality = c.String(),
                        CaptainName = c.String(),
                        CrewSize = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        MaxLoadKilograms = c.Int(),
                        PassangerCapacity = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ShiftCount = c.Int(nullable: false),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bikes", "Id", "dbo.Vehicles");
            DropForeignKey("dbo.Ships", "Id", "dbo.Vehicles");
            DropForeignKey("dbo.Planes", "Id", "dbo.Vehicles");
            DropForeignKey("dbo.Cars", "Id", "dbo.Vehicles");
            DropForeignKey("dbo.Trains", "Id", "dbo.Vehicles");
            DropForeignKey("dbo.Locomotives", "Id", "dbo.Trains");
            DropForeignKey("dbo.Carriages", "Train_Id", "dbo.Trains");
            DropIndex("dbo.Bikes", new[] { "Id" });
            DropIndex("dbo.Ships", new[] { "Id" });
            DropIndex("dbo.Planes", new[] { "Id" });
            DropIndex("dbo.Cars", new[] { "Id" });
            DropIndex("dbo.Trains", new[] { "Id" });
            DropIndex("dbo.Locomotives", new[] { "Id" });
            DropIndex("dbo.Carriages", new[] { "Train_Id" });
            DropTable("dbo.Bikes");
            DropTable("dbo.Ships");
            DropTable("dbo.Planes");
            DropTable("dbo.Cars");
            DropTable("dbo.Trains");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Locomotives");
            DropTable("dbo.Carriages");
        }
    }
}
