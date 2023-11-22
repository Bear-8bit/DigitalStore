namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedReview : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.tb_Review", "GameId");
            AddForeignKey("dbo.tb_Review", "GameId", "dbo.tb_Game", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Review", "GameId", "dbo.tb_Game");
            DropIndex("dbo.tb_Review", new[] { "GameId" });
        }
    }
}
