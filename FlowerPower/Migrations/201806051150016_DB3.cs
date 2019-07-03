namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bestellings", "WinkelId_Id", "dbo.Winkels");
            DropForeignKey("dbo.Factuurs", "BestellingId_Id", "dbo.Bestellings");
            DropForeignKey("dbo.Factuurs", "WinkelId_Id", "dbo.Winkels");
            DropIndex("dbo.Factuurs", new[] { "BestellingId_Id" });
            DropIndex("dbo.Factuurs", new[] { "WinkelId_Id" });
            DropIndex("dbo.Bestellings", new[] { "WinkelId_Id" });
            DropColumn("dbo.Factuurs", "BestellingId_Id");
            DropColumn("dbo.Factuurs", "WinkelId_Id");
            DropTable("dbo.Bestellings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Bestellings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BestelDatum = c.DateTime(nullable: false),
                        WinkelId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Factuurs", "WinkelId_Id", c => c.Int());
            AddColumn("dbo.Factuurs", "BestellingId_Id", c => c.Int());
            CreateIndex("dbo.Bestellings", "WinkelId_Id");
            CreateIndex("dbo.Factuurs", "WinkelId_Id");
            CreateIndex("dbo.Factuurs", "BestellingId_Id");
            AddForeignKey("dbo.Factuurs", "WinkelId_Id", "dbo.Winkels", "Id");
            AddForeignKey("dbo.Factuurs", "BestellingId_Id", "dbo.Bestellings", "Id");
            AddForeignKey("dbo.Bestellings", "WinkelId_Id", "dbo.Winkels", "Id");
        }
    }
}
