namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB1337 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FactuurRegels", "FiliaalKeuze", c => c.String());
            DropColumn("dbo.FactuurRegels", "Stuks");
            DropTable("dbo.KiesWinkels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.KiesWinkels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FiliaalKeuze = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.FactuurRegels", "Stuks", c => c.Int(nullable: false));
            DropColumn("dbo.FactuurRegels", "FiliaalKeuze");
        }
    }
}
