namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bestellings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BestelDatum = c.DateTime(nullable: false),
                        WinkelId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Winkels", t => t.WinkelId_Id)
                .Index(t => t.WinkelId_Id);
            
            CreateTable(
                "dbo.Winkels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Straat = c.String(nullable: false),
                        Postcode = c.String(nullable: false),
                        Plaats = c.String(nullable: false),
                        Plaatje = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FactuurRegels", "Stuks", c => c.Int(nullable: false));
            AddColumn("dbo.Factuurs", "BestellingId_Id", c => c.Int());
            AddColumn("dbo.Factuurs", "WinkelId_Id", c => c.Int());
            CreateIndex("dbo.Factuurs", "BestellingId_Id");
            CreateIndex("dbo.Factuurs", "WinkelId_Id");
            AddForeignKey("dbo.Factuurs", "BestellingId_Id", "dbo.Bestellings", "Id");
            AddForeignKey("dbo.Factuurs", "WinkelId_Id", "dbo.Winkels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factuurs", "WinkelId_Id", "dbo.Winkels");
            DropForeignKey("dbo.Factuurs", "BestellingId_Id", "dbo.Bestellings");
            DropForeignKey("dbo.Bestellings", "WinkelId_Id", "dbo.Winkels");
            DropIndex("dbo.Bestellings", new[] { "WinkelId_Id" });
            DropIndex("dbo.Factuurs", new[] { "WinkelId_Id" });
            DropIndex("dbo.Factuurs", new[] { "BestellingId_Id" });
            DropColumn("dbo.Factuurs", "WinkelId_Id");
            DropColumn("dbo.Factuurs", "BestellingId_Id");
            DropColumn("dbo.FactuurRegels", "Stuks");
            DropTable("dbo.Winkels");
            DropTable("dbo.Bestellings");
        }
    }
}
