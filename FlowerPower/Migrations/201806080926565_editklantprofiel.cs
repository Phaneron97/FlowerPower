namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editklantprofiel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Klants", "Voornaam", c => c.String(nullable: false));
            AddColumn("dbo.Klants", "Tussenvoegsel", c => c.String());
            AddColumn("dbo.Klants", "Achternaam", c => c.String(nullable: false));
            AddColumn("dbo.Klants", "Straat", c => c.String(nullable: false));
            AddColumn("dbo.Klants", "Postcode", c => c.String(nullable: false));
            AddColumn("dbo.Klants", "Plaats", c => c.String(nullable: false));
            AddColumn("dbo.Klants", "GeboorteDatum", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Klants", "GeboorteDatum");
            DropColumn("dbo.Klants", "Plaats");
            DropColumn("dbo.Klants", "Postcode");
            DropColumn("dbo.Klants", "Straat");
            DropColumn("dbo.Klants", "Achternaam");
            DropColumn("dbo.Klants", "Tussenvoegsel");
            DropColumn("dbo.Klants", "Voornaam");
        }
    }
}
