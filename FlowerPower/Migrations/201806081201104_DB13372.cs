namespace FlowerPower.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB13372 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.FactuurRegels", name: "Winkelnaam_Id", newName: "WinkelId_Id");
            RenameIndex(table: "dbo.FactuurRegels", name: "IX_Winkelnaam_Id", newName: "IX_WinkelId_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.FactuurRegels", name: "IX_WinkelId_Id", newName: "IX_Winkelnaam_Id");
            RenameColumn(table: "dbo.FactuurRegels", name: "WinkelId_Id", newName: "Winkelnaam_Id");
        }
    }
}
