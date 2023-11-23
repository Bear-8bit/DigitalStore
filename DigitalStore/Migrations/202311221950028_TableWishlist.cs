namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableWishlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Wishlist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        UserName = c.String(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_Game", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Wishlist", "GameId", "dbo.tb_Game");
            DropIndex("dbo.tb_Wishlist", new[] { "GameId" });
            DropTable("dbo.tb_Wishlist");
        }
    }
}
