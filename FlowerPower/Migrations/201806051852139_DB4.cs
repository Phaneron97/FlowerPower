namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Klants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Klants", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Klants", new[] { "User_Id" });
            DropTable("dbo.Klants");
        }
    }
}
