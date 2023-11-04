namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedContract : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Contract", "Contract_Code", c => c.String());
            AddColumn("dbo.tb_Contract", "NameSideA", c => c.String());
            AddColumn("dbo.tb_Contract", "NameSideB", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Contract", "NameSideB");
            DropColumn("dbo.tb_Contract", "NameSideA");
            DropColumn("dbo.tb_Contract", "Contract_Code");
        }
    }
}
