namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForgienKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Voucher", "VoucherCategory_Id", "dbo.tb_VoucherCategory");
            DropIndex("dbo.tb_Voucher", new[] { "VoucherCategory_Id" });
            DropColumn("dbo.tb_Voucher", "VoucherType");
            RenameColumn(table: "dbo.tb_Voucher", name: "VoucherCategory_Id", newName: "VoucherType");
            AlterColumn("dbo.tb_Voucher", "VoucherType", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Voucher", "VoucherType");
            AddForeignKey("dbo.tb_Voucher", "VoucherType", "dbo.tb_VoucherCategory", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Voucher", "VoucherType", "dbo.tb_VoucherCategory");
            DropIndex("dbo.tb_Voucher", new[] { "VoucherType" });
            AlterColumn("dbo.tb_Voucher", "VoucherType", c => c.Int());
            RenameColumn(table: "dbo.tb_Voucher", name: "VoucherType", newName: "VoucherCategory_Id");
            AddColumn("dbo.tb_Voucher", "VoucherType", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Voucher", "VoucherCategory_Id");
            AddForeignKey("dbo.tb_Voucher", "VoucherCategory_Id", "dbo.tb_VoucherCategory", "Id");
        }
    }
}
