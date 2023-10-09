namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedGameNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_GameNews", "Publisher_Id", c => c.Int());
            CreateIndex("dbo.tb_GameNews", "Publisher_Id");
            AddForeignKey("dbo.tb_GameNews", "Publisher_Id", "dbo.tb_Publisher", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_GameNews", "Publisher_Id", "dbo.tb_Publisher");
            DropIndex("dbo.tb_GameNews", new[] { "Publisher_Id" });
            DropColumn("dbo.tb_GameNews", "Publisher_Id");
        }
    }
}
