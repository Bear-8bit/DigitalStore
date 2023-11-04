namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contract1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Contract", "ContractCategories_Id", "dbo.tb_ContractCategory");
            DropIndex("dbo.tb_Contract", new[] { "ContractCategories_Id" });
            RenameColumn(table: "dbo.tb_Contract", name: "ContractCategories_Id", newName: "ContractCategoryId");
            AlterColumn("dbo.tb_Contract", "ContractCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Contract", "ContractCategoryId");
            AddForeignKey("dbo.tb_Contract", "ContractCategoryId", "dbo.tb_ContractCategory", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Contract", "ContractCategoryId", "dbo.tb_ContractCategory");
            DropIndex("dbo.tb_Contract", new[] { "ContractCategoryId" });
            AlterColumn("dbo.tb_Contract", "ContractCategoryId", c => c.Int());
            RenameColumn(table: "dbo.tb_Contract", name: "ContractCategoryId", newName: "ContractCategories_Id");
            CreateIndex("dbo.tb_Contract", "ContractCategories_Id");
            AddForeignKey("dbo.tb_Contract", "ContractCategories_Id", "dbo.tb_ContractCategory", "Id");
        }
    }
}
