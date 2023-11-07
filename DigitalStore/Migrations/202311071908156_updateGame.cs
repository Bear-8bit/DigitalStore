namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGame : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Game", "Publishers_Id", "dbo.tb_Publisher");
            DropIndex("dbo.tb_Game", new[] { "Publishers_Id" });
            RenameColumn(table: "dbo.tb_Game", name: "Publishers_Id", newName: "PublisherId");
            AlterColumn("dbo.tb_Game", "PublisherId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Game", "PublisherId");
            AddForeignKey("dbo.tb_Game", "PublisherId", "dbo.tb_Publisher", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Game", "PublisherId", "dbo.tb_Publisher");
            DropIndex("dbo.tb_Game", new[] { "PublisherId" });
            AlterColumn("dbo.tb_Game", "PublisherId", c => c.Int());
            RenameColumn(table: "dbo.tb_Game", name: "PublisherId", newName: "Publishers_Id");
            CreateIndex("dbo.tb_Game", "Publishers_Id");
            AddForeignKey("dbo.tb_Game", "Publishers_Id", "dbo.tb_Publisher", "Id");
        }
    }
}
