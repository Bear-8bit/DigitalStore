namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVOucher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderViewModels", "VoucherId", "dbo.tb_Voucher");
            DropForeignKey("dbo.tb_Order", "VoucherId", "dbo.tb_Voucher");
            DropIndex("dbo.tb_Order", new[] { "VoucherId" });
            DropIndex("dbo.OrderViewModels", new[] { "VoucherId" });
            RenameColumn(table: "dbo.tb_Order", name: "VoucherId", newName: "Voucher_Id");
            AddColumn("dbo.tb_Order", "VoucherCode", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_Order", "Voucher_Id", c => c.Int());
            CreateIndex("dbo.tb_Order", "Voucher_Id");
            AddForeignKey("dbo.tb_Order", "Voucher_Id", "dbo.tb_Voucher", "Id");
            DropTable("dbo.OrderViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        CustomerId = c.String(),
                        Quantity = c.Int(nullable: false),
                        TypePayment = c.Int(nullable: false),
                        TypePaymentVN = c.Int(nullable: false),
                        VoucherId = c.Int(nullable: false),
                        DiscountPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.tb_Order", "Voucher_Id", "dbo.tb_Voucher");
            DropIndex("dbo.tb_Order", new[] { "Voucher_Id" });
            AlterColumn("dbo.tb_Order", "Voucher_Id", c => c.Int(nullable: false));
            DropColumn("dbo.tb_Order", "VoucherCode");
            RenameColumn(table: "dbo.tb_Order", name: "Voucher_Id", newName: "VoucherId");
            CreateIndex("dbo.OrderViewModels", "VoucherId");
            CreateIndex("dbo.tb_Order", "VoucherId");
            AddForeignKey("dbo.tb_Order", "VoucherId", "dbo.tb_Voucher", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderViewModels", "VoucherId", "dbo.tb_Voucher", "Id", cascadeDelete: true);
        }
    }
}
