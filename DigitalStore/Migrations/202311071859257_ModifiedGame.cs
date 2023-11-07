namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedGame : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.tb_Game", name: "Publisher_Id", newName: "Publishers_Id");
            RenameIndex(table: "dbo.tb_Game", name: "IX_Publisher_Id", newName: "IX_Publishers_Id");
            AddColumn("dbo.tb_Game", "PublisherName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Game", "PublisherName");
            RenameIndex(table: "dbo.tb_Game", name: "IX_Publishers_Id", newName: "IX_Publisher_Id");
            RenameColumn(table: "dbo.tb_Game", name: "Publishers_Id", newName: "Publisher_Id");
        }
    }
}
