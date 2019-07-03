namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class factuur1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bloems", "Prijs", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bloems", "Prijs", c => c.Single(nullable: false));
        }
    }
}
