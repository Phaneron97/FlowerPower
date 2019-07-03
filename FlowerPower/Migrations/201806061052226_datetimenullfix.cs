namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimenullfix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "GeboorteDatum", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "GeboorteDatum", c => c.DateTime(nullable: false));
        }
    }
}
