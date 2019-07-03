namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bestellingenview : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bestellings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Klaar = c.Boolean(nullable: false),
                        FactuurRegel_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                        WinkelId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FactuurRegels", t => t.FactuurRegel_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Winkels", t => t.WinkelId_Id)
                .Index(t => t.FactuurRegel_Id)
                .Index(t => t.User_Id)
                .Index(t => t.WinkelId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bestellings", "WinkelId_Id", "dbo.Winkels");
            DropForeignKey("dbo.Bestellings", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Bestellings", "FactuurRegel_Id", "dbo.FactuurRegels");
            DropIndex("dbo.Bestellings", new[] { "WinkelId_Id" });
            DropIndex("dbo.Bestellings", new[] { "User_Id" });
            DropIndex("dbo.Bestellings", new[] { "FactuurRegel_Id" });
            DropTable("dbo.Bestellings");
        }
    }
}
