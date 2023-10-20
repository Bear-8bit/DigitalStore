namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuAlias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Menu", "Alias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Menu", "Alias");
        }
    }
}
