namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGameEF1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Game", "IsNew", c => c.Boolean(nullable: false));
            DropColumn("dbo.tb_Game", "IsHot");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Game", "IsHot", c => c.Boolean(nullable: false));
            DropColumn("dbo.tb_Game", "IsNew");
        }
    }
}
