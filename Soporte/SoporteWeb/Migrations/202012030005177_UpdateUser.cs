namespace SoporteWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Costoes", name: "User_Id", newName: "ApplicationUser");
            RenameIndex(table: "dbo.Costoes", name: "IX_User_Id", newName: "IX_ApplicationUser");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Costoes", name: "IX_ApplicationUser", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Costoes", name: "ApplicationUser", newName: "User_Id");
        }
    }
}
