namespace BankSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CheckingAccount",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Fee = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.SavingsAccount",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        InterestRate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankAccounts", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavingsAccount", "Id", "dbo.BankAccounts");
            DropForeignKey("dbo.CheckingAccount", "Id", "dbo.BankAccounts");
            DropForeignKey("dbo.BankAccounts", "User_Id", "dbo.Users");
            DropIndex("dbo.SavingsAccount", new[] { "Id" });
            DropIndex("dbo.CheckingAccount", new[] { "Id" });
            DropIndex("dbo.BankAccounts", new[] { "User_Id" });
            DropTable("dbo.SavingsAccount");
            DropTable("dbo.CheckingAccount");
            DropTable("dbo.Users");
            DropTable("dbo.BankAccounts");
        }
    }
}
