namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Winkelteruggedraaid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FactuurRegels", "FiliaalKeuze", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FactuurRegels", "FiliaalKeuze");
        }
    }
}
