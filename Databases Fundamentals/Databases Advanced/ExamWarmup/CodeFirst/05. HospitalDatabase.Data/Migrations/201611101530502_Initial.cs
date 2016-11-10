namespace _05.HospitalDatabase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diagnoses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Comments = c.String(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Specialty = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visitations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        Comments = c.String(),
                        Doctor_Id = c.Int(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Medicaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(),
                        Picture = c.Binary(),
                        IsMedicallyInsured = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitations", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Medicaments", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Diagnoses", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Visitations", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Medicaments", new[] { "Patient_Id" });
            DropIndex("dbo.Visitations", new[] { "Patient_Id" });
            DropIndex("dbo.Visitations", new[] { "Doctor_Id" });
            DropIndex("dbo.Diagnoses", new[] { "Patient_Id" });
            DropTable("dbo.Patients");
            DropTable("dbo.Medicaments");
            DropTable("dbo.Visitations");
            DropTable("dbo.Doctors");
            DropTable("dbo.Diagnoses");
        }
    }
}
