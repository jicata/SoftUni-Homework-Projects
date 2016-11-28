namespace BusTicketSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        AccountNumber = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(),
                        Gender = c.Int(nullable: false),
                        HomeTownId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Towns", t => t.HomeTownId, cascadeDelete: true)
                .Index(t => t.HomeTownId);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BusStations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Town_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Towns", t => t.Town_Id)
                .Index(t => t.Town_Id);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartureTime = c.DateTime(),
                        ArrivalTime = c.DateTime(),
                        Status = c.Int(nullable: false),
                        BusCompany_Id = c.Int(),
                        DestinationBusStation_Id = c.Int(),
                        OriginBusStation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusCompanies", t => t.BusCompany_Id)
                .ForeignKey("dbo.BusStations", t => t.DestinationBusStation_Id)
                .ForeignKey("dbo.BusStations", t => t.OriginBusStation_Id)
                .Index(t => t.BusCompany_Id)
                .Index(t => t.DestinationBusStation_Id)
                .Index(t => t.OriginBusStation_Id);
            
            CreateTable(
                "dbo.BusCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Nationality = c.String(),
                        Rating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Grade = c.Single(nullable: false),
                        PublishedOn = c.DateTime(),
                        BusCompany_Id = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusCompanies", t => t.BusCompany_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.BusCompany_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        TripId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Seat = c.String(),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.TripId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.TripId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccounts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "HomeTownId", "dbo.Towns");
            DropForeignKey("dbo.Tickets", "TripId", "dbo.Trips");
            DropForeignKey("dbo.Tickets", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Trips", "OriginBusStation_Id", "dbo.BusStations");
            DropForeignKey("dbo.Trips", "DestinationBusStation_Id", "dbo.BusStations");
            DropForeignKey("dbo.Trips", "BusCompany_Id", "dbo.BusCompanies");
            DropForeignKey("dbo.Reviews", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Reviews", "BusCompany_Id", "dbo.BusCompanies");
            DropForeignKey("dbo.BusStations", "Town_Id", "dbo.Towns");
            DropIndex("dbo.Tickets", new[] { "TripId" });
            DropIndex("dbo.Tickets", new[] { "CustomerId" });
            DropIndex("dbo.Reviews", new[] { "Customer_Id" });
            DropIndex("dbo.Reviews", new[] { "BusCompany_Id" });
            DropIndex("dbo.Trips", new[] { "OriginBusStation_Id" });
            DropIndex("dbo.Trips", new[] { "DestinationBusStation_Id" });
            DropIndex("dbo.Trips", new[] { "BusCompany_Id" });
            DropIndex("dbo.BusStations", new[] { "Town_Id" });
            DropIndex("dbo.Customers", new[] { "HomeTownId" });
            DropIndex("dbo.BankAccounts", new[] { "CustomerId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Reviews");
            DropTable("dbo.BusCompanies");
            DropTable("dbo.Trips");
            DropTable("dbo.BusStations");
            DropTable("dbo.Towns");
            DropTable("dbo.Customers");
            DropTable("dbo.BankAccounts");
        }
    }
}
