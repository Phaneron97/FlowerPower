namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FactuurRegels", "Winkelnaam_Id", c => c.Int());
            CreateIndex("dbo.FactuurRegels", "Winkelnaam_Id");
            AddForeignKey("dbo.FactuurRegels", "Winkelnaam_Id", "dbo.Winkels", "Id");
            DropColumn("dbo.FactuurRegels", "FiliaalKeuze");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FactuurRegels", "FiliaalKeuze", c => c.String());
            DropForeignKey("dbo.FactuurRegels", "Winkelnaam_Id", "dbo.Winkels");
            DropIndex("dbo.FactuurRegels", new[] { "Winkelnaam_Id" });
            DropColumn("dbo.FactuurRegels", "Winkelnaam_Id");
        }
    }
}
