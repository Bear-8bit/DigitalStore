namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TempContract : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Contract", "PublisherId", "dbo.tb_Publisher");
            DropIndex("dbo.tb_Contract", new[] { "PublisherId" });
            RenameColumn(table: "dbo.tb_Contract", name: "PublisherId", newName: "Publisher_Id");
            AlterColumn("dbo.tb_Contract", "Publisher_Id", c => c.Int());
            CreateIndex("dbo.tb_Contract", "Publisher_Id");
            AddForeignKey("dbo.tb_Contract", "Publisher_Id", "dbo.tb_Publisher", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Contract", "Publisher_Id", "dbo.tb_Publisher");
            DropIndex("dbo.tb_Contract", new[] { "Publisher_Id" });
            AlterColumn("dbo.tb_Contract", "Publisher_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.tb_Contract", name: "Publisher_Id", newName: "PublisherId");
            CreateIndex("dbo.tb_Contract", "PublisherId");
            AddForeignKey("dbo.tb_Contract", "PublisherId", "dbo.tb_Publisher", "Id", cascadeDelete: true);
        }
    }
}
