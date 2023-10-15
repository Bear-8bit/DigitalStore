namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAlias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_GameGenre", "Alias", c => c.String());
            AddColumn("dbo.tn_Game", "Alias", c => c.String());
            AddColumn("dbo.tb_GameNews", "Alias", c => c.String());
            AddColumn("dbo.tb_NewsCategory", "Alias", c => c.String());
            AddColumn("dbo.tb_Publisher", "Alias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Publisher", "Alias");
            DropColumn("dbo.tb_NewsCategory", "Alias");
            DropColumn("dbo.tb_GameNews", "Alias");
            DropColumn("dbo.tn_Game", "Alias");
            DropColumn("dbo.tb_GameGenre", "Alias");
        }
    }
}
