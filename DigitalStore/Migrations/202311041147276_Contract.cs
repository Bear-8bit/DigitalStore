namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contract : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Contract",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractCateId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActiveDate = c.DateTime(),
                        ExpireDate = c.DateTime(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        ContractCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_ContractCategory", t => t.ContractCategory_Id)
                .ForeignKey("dbo.tb_Publisher", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.PublisherId)
                .Index(t => t.ContractCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Contract", "PublisherId", "dbo.tb_Publisher");
            DropForeignKey("dbo.tb_Contract", "ContractCategory_Id", "dbo.tb_ContractCategory");
            DropIndex("dbo.tb_Contract", new[] { "ContractCategory_Id" });
            DropIndex("dbo.tb_Contract", new[] { "PublisherId" });
            DropTable("dbo.tb_Contract");
        }
    }
}
