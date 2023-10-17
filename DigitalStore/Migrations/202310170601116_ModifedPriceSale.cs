namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifedPriceSale : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tn_Game", "PriceSale", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tn_Game", "PriceSale", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
