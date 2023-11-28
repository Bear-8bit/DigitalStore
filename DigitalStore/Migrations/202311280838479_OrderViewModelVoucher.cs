namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderViewModelVoucher : DbMigration
    {
        public override void Up()
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Voucher", t => t.VoucherId, cascadeDelete: true)
                .Index(t => t.VoucherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderViewModels", "VoucherId", "dbo.tb_Voucher");
            DropIndex("dbo.OrderViewModels", new[] { "VoucherId" });
            DropTable("dbo.OrderViewModels");
        }
    }
}
