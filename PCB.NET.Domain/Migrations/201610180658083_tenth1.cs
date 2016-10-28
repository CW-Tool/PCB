namespace PCB.NET.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenth1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("store.OtherStore", "ItemId", "store.Item");
            DropIndex("store.OtherStore", new[] { "ItemId" });
            RenameColumn(table: "store.OtherStore", name: "ItemId", newName: "Item_ItemId");
            AlterColumn("store.OtherStore", "Item_ItemId", c => c.Int());
            CreateIndex("store.OtherStore", "Item_ItemId");
            AddForeignKey("store.OtherStore", "Item_ItemId", "store.Item", "ItemId");
        }
        
        public override void Down()
        {
            DropForeignKey("store.OtherStore", "Item_ItemId", "store.Item");
            DropIndex("store.OtherStore", new[] { "Item_ItemId" });
            AlterColumn("store.OtherStore", "Item_ItemId", c => c.Int(nullable: false));
            RenameColumn(table: "store.OtherStore", name: "Item_ItemId", newName: "ItemId");
            CreateIndex("store.OtherStore", "ItemId");
            AddForeignKey("store.OtherStore", "ItemId", "store.Item", "ItemId", cascadeDelete: true);
        }
    }
}
