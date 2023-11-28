namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Order", "VoucherCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Order", "VoucherCode", c => c.Int(nullable: false));
        }
    }
}
