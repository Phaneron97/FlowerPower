namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class factuurfix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medewerkers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TijdelijkWachtwoord = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medewerkers", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Medewerkers", new[] { "User_Id" });
            DropTable("dbo.Medewerkers");
        }
    }
}
