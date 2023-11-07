namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarketingPartner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_MarketingPartner",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Alias = c.String(),
                        Email = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tb_Contract", "MarketingPartner_Id", c => c.Int());
            CreateIndex("dbo.tb_Contract", "MarketingPartner_Id");
            AddForeignKey("dbo.tb_Contract", "MarketingPartner_Id", "dbo.tb_MarketingPartner", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Contract", "MarketingPartner_Id", "dbo.tb_MarketingPartner");
            DropIndex("dbo.tb_Contract", new[] { "MarketingPartner_Id" });
            DropColumn("dbo.tb_Contract", "MarketingPartner_Id");
            DropTable("dbo.tb_MarketingPartner");
        }
    }
}
