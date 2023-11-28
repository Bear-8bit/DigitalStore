namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderVoucher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "VoucherId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Order", "VoucherId");
            AddForeignKey("dbo.tb_Order", "VoucherId", "dbo.tb_Voucher", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Order", "VoucherId", "dbo.tb_Voucher");
            DropIndex("dbo.tb_Order", new[] { "VoucherId" });
            DropColumn("dbo.tb_Order", "VoucherId");
        }
    }
}
