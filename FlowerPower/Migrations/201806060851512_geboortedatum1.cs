namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class geboortedatum1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GeboorteDatum", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "GeboorteDatum_CommandTimeout");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "GeboorteDatum_CommandTimeout", c => c.Int());
            DropColumn("dbo.AspNetUsers", "GeboorteDatum");
        }
    }
}
