namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Order", "Order_Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Order", "Order_Date", c => c.DateTime(nullable: false));
        }
    }
}
