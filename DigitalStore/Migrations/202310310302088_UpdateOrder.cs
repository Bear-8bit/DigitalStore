namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_OrderDetail", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Order", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Order", "Quantity");
            DropColumn("dbo.tb_OrderDetail", "Quantity");
        }
    }
}
