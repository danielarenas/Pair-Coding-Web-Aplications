namespace SoporteWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartProject1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Costoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        TipoId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipoes", t => t.TipoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.TipoId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Tipoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Costoes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Costoes", "TipoId", "dbo.Tipoes");
            DropIndex("dbo.Costoes", new[] { "User_Id" });
            DropIndex("dbo.Costoes", new[] { "TipoId" });
            DropTable("dbo.Tipoes");
            DropTable("dbo.Costoes");
        }
    }
}
