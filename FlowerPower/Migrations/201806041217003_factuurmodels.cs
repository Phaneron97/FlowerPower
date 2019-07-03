namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class factuurmodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Voornaam", c => c.String());
            AddColumn("dbo.AspNetUsers", "Tussenvoegsel", c => c.String());
            AddColumn("dbo.AspNetUsers", "Achternaam", c => c.String());
            AddColumn("dbo.AspNetUsers", "Straat", c => c.String());
            AddColumn("dbo.AspNetUsers", "Postcode", c => c.String());
            AddColumn("dbo.AspNetUsers", "Plaats", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Plaats");
            DropColumn("dbo.AspNetUsers", "Postcode");
            DropColumn("dbo.AspNetUsers", "Straat");
            DropColumn("dbo.AspNetUsers", "Achternaam");
            DropColumn("dbo.AspNetUsers", "Tussenvoegsel");
            DropColumn("dbo.AspNetUsers", "Voornaam");
        }
    }
}
