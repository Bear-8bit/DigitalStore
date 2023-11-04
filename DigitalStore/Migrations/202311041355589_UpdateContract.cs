namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContract : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Contract", "ActiveDate", c => c.DateTime());
            AlterColumn("dbo.tb_Contract", "ExpireDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Contract", "ExpireDate", c => c.String());
            AlterColumn("dbo.tb_Contract", "ActiveDate", c => c.String());
        }
    }
}
