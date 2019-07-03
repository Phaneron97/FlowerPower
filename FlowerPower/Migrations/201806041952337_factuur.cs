namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class factuur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FactuurRegels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BloemId_Id = c.Int(),
                        FactuurId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bloems", t => t.BloemId_Id)
                .ForeignKey("dbo.Factuurs", t => t.FactuurId_Id)
                .Index(t => t.BloemId_Id)
                .Index(t => t.FactuurId_Id);
            
            CreateTable(
                "dbo.Factuurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BestelDatum = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AlterColumn("dbo.Bloems", "Prijs", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FactuurRegels", "FactuurId_Id", "dbo.Factuurs");
            DropForeignKey("dbo.Factuurs", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FactuurRegels", "BloemId_Id", "dbo.Bloems");
            DropIndex("dbo.Factuurs", new[] { "User_Id" });
            DropIndex("dbo.FactuurRegels", new[] { "FactuurId_Id" });
            DropIndex("dbo.FactuurRegels", new[] { "BloemId_Id" });
            AlterColumn("dbo.Bloems", "Prijs", c => c.String(nullable: false));
            DropTable("dbo.Factuurs");
            DropTable("dbo.FactuurRegels");
        }
    }
}
