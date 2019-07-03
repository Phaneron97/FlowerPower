namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB41 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KiesWinkels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FiliaalKeuze = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Winkels", "Winkelnaam", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Winkels", "Winkelnaam");
            DropTable("dbo.KiesWinkels");
        }
    }
}
