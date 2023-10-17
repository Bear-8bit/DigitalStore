namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifedGameEF : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_GameImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameID = c.Int(nullable: false),
                        Image = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tn_Game", t => t.GameID, cascadeDelete: true)
                .Index(t => t.GameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_GameImage", "GameID", "dbo.tn_Game");
            DropIndex("dbo.tb_GameImage", new[] { "GameID" });
            DropTable("dbo.tb_GameImage");
        }
    }
}
