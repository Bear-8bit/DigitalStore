namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedContractCate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_ContractCategory", "Description", c => c.String());
            AddColumn("dbo.tb_ContractCategory", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_ContractCategory", "IsActive");
            DropColumn("dbo.tb_ContractCategory", "Description");
        }
    }
}
