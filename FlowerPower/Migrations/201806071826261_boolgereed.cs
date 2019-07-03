namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boolgereed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Factuurs", "Gereed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Factuurs", "Gereed");
        }
    }
}
