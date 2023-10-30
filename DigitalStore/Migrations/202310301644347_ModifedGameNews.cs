namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifedGameNews : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_GameNews", "Game_Id", "dbo.tb_Game");
            DropForeignKey("dbo.tb_GameNews", "Publisher_Id", "dbo.tb_Publisher");
            DropIndex("dbo.tb_GameNews", new[] { "Game_Id" });
            DropIndex("dbo.tb_GameNews", new[] { "Publisher_Id" });
            RenameColumn(table: "dbo.tb_GameNews", name: "Game_Id", newName: "GameID");
            RenameColumn(table: "dbo.tb_GameNews", name: "Publisher_Id", newName: "PublisherID");
            AddColumn("dbo.tb_GameNews", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_GameNews", "GameID", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_GameNews", "PublisherID", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_GameNews", "PublisherID");
            CreateIndex("dbo.tb_GameNews", "GameID");
            AddForeignKey("dbo.tb_GameNews", "GameID", "dbo.tb_Game", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_GameNews", "PublisherID", "dbo.tb_Publisher", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_GameNews", "PublisherID", "dbo.tb_Publisher");
            DropForeignKey("dbo.tb_GameNews", "GameID", "dbo.tb_Game");
            DropIndex("dbo.tb_GameNews", new[] { "GameID" });
            DropIndex("dbo.tb_GameNews", new[] { "PublisherID" });
            AlterColumn("dbo.tb_GameNews", "PublisherID", c => c.Int());
            AlterColumn("dbo.tb_GameNews", "GameID", c => c.Int());
            DropColumn("dbo.tb_GameNews", "CategoryID");
            RenameColumn(table: "dbo.tb_GameNews", name: "PublisherID", newName: "Publisher_Id");
            RenameColumn(table: "dbo.tb_GameNews", name: "GameID", newName: "Game_Id");
            CreateIndex("dbo.tb_GameNews", "Publisher_Id");
            CreateIndex("dbo.tb_GameNews", "Game_Id");
            AddForeignKey("dbo.tb_GameNews", "Publisher_Id", "dbo.tb_Publisher", "Id");
            AddForeignKey("dbo.tb_GameNews", "Game_Id", "dbo.tb_Game", "Id");
        }
    }
}
