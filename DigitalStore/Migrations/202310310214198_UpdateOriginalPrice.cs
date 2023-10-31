namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOriginalPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Game", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Game", "OriginalPrice");
        }
    }
}
