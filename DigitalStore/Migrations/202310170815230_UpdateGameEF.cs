namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGameEF : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tn_Game", newName: "tb_Game");
            DropForeignKey("dbo.tn_Game", "GameGenres_Id", "dbo.tb_GameGenre");
            DropIndex("dbo.tb_Game", new[] { "GameGenres_Id" });
            RenameColumn(table: "dbo.tb_Game", name: "GameGenres_Id", newName: "GameGenreId");
            AlterColumn("dbo.tb_Game", "GameGenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Game", "GameGenreId");
            AddForeignKey("dbo.tb_Game", "GameGenreId", "dbo.tb_GameGenre", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Game", "GameGenreId", "dbo.tb_GameGenre");
            DropIndex("dbo.tb_Game", new[] { "GameGenreId" });
            AlterColumn("dbo.tb_Game", "GameGenreId", c => c.Int());
            RenameColumn(table: "dbo.tb_Game", name: "GameGenreId", newName: "GameGenres_Id");
            CreateIndex("dbo.tb_Game", "GameGenres_Id");
            AddForeignKey("dbo.tn_Game", "GameGenres_Id", "dbo.tb_GameGenre", "Id");
            RenameTable(name: "dbo.tb_Game", newName: "tn_Game");
        }
    }
}
