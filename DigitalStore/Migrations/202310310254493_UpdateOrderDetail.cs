namespace DigitalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_OrderDetail", "Game_Id", "dbo.tb_Game");
            DropForeignKey("dbo.tb_OrderDetail", "Order_Id", "dbo.tb_Order");
            DropIndex("dbo.tb_OrderDetail", new[] { "Game_Id" });
            DropIndex("dbo.tb_OrderDetail", new[] { "Order_Id" });
            RenameColumn(table: "dbo.tb_OrderDetail", name: "Game_Id", newName: "GameId");
            RenameColumn(table: "dbo.tb_OrderDetail", name: "Order_Id", newName: "OrderId");
            AlterColumn("dbo.tb_OrderDetail", "GameId", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_OrderDetail", "OrderId");
            CreateIndex("dbo.tb_OrderDetail", "GameId");
            AddForeignKey("dbo.tb_OrderDetail", "GameId", "dbo.tb_Game", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_OrderDetail", "OrderId", "dbo.tb_Order");
            DropForeignKey("dbo.tb_OrderDetail", "GameId", "dbo.tb_Game");
            DropIndex("dbo.tb_OrderDetail", new[] { "GameId" });
            DropIndex("dbo.tb_OrderDetail", new[] { "OrderId" });
            AlterColumn("dbo.tb_OrderDetail", "OrderId", c => c.Int());
            AlterColumn("dbo.tb_OrderDetail", "GameId", c => c.Int());
            RenameColumn(table: "dbo.tb_OrderDetail", name: "OrderId", newName: "Order_Id");
            RenameColumn(table: "dbo.tb_OrderDetail", name: "GameId", newName: "Game_Id");
            CreateIndex("dbo.tb_OrderDetail", "Order_Id");
            CreateIndex("dbo.tb_OrderDetail", "Game_Id");
            AddForeignKey("dbo.tb_OrderDetail", "Order_Id", "dbo.tb_Order", "Id");
            AddForeignKey("dbo.tb_OrderDetail", "Game_Id", "dbo.tb_Game", "Id");
        }
    }
}
