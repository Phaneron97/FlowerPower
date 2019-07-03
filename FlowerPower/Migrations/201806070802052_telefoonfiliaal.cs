namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class telefoonfiliaal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Winkels", "Telefoon", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Winkels", "Telefoon");
        }
    }
}
