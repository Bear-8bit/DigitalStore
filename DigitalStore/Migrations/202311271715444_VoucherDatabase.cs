namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoucherDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_VoucherCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Voucher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoucherType = c.Int(nullable: false),
                        VoucherCode = c.String(),
                        DiscountPrice = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        VoucherCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_VoucherCategory", t => t.VoucherCategory_Id)
                .Index(t => t.VoucherCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Voucher", "VoucherCategory_Id", "dbo.tb_VoucherCategory");
            DropIndex("dbo.tb_Voucher", new[] { "VoucherCategory_Id" });
            DropTable("dbo.tb_Voucher");
            DropTable("dbo.tb_VoucherCategory");
        }
    }
}
