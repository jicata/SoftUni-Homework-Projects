namespace CarDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_FK_PartsSupplier : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parts", "Supplier_Id", "dbo.Suppliers");
            DropIndex("dbo.Parts", new[] { "Supplier_Id" });
            RenameColumn(table: "dbo.Parts", name: "Supplier_Id", newName: "SupplierId");
            AlterColumn("dbo.Parts", "SupplierId", c => c.Int(nullable: false));
            CreateIndex("dbo.Parts", "SupplierId");
            AddForeignKey("dbo.Parts", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Parts", new[] { "SupplierId" });
            AlterColumn("dbo.Parts", "SupplierId", c => c.Int());
            RenameColumn(table: "dbo.Parts", name: "SupplierId", newName: "Supplier_Id");
            CreateIndex("dbo.Parts", "Supplier_Id");
            AddForeignKey("dbo.Parts", "Supplier_Id", "dbo.Suppliers", "Id");
        }
    }
}
