namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class geboortedatum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GeboorteDatum_CommandTimeout", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GeboorteDatum_CommandTimeout");
        }
    }
}
