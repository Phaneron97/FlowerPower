namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bloemmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bloems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(nullable: false),
                        Prijs = c.String(nullable: false),
                        Omschrijving = c.String(nullable: false),
                        Plaatje = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bloems");
        }
    }
}
