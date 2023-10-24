namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeCommon : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_GameGenre", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tb_Game", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tb_GameNews", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tb_NewsCategory", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tb_Publisher", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tb_Order", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tb_Menu", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Menu", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.tb_Order", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.tb_Publisher", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.tb_NewsCategory", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.tb_GameNews", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.tb_Game", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.tb_GameGenre", "CreatedDate", c => c.DateTime());
        }
    }
}
