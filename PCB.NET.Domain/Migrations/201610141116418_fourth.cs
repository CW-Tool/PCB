namespace PCB.NET.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "store.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        NameItem = c.String(nullable: false),
                        DescriptionItem = c.String(),
                        SMDId = c.Int(nullable: false),
                        HangingId = c.Int(nullable: false),
                        OtherStoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "store.OtherStore",
                c => new
                    {
                        OtherStoreId = c.Int(nullable: false, identity: true),
                        ValueItemOne = c.Double(nullable: false),
                        ValueItemTwo = c.Double(nullable: false),
                        DescriptionItemOne = c.String(),
                        DescriptionItemTwo = c.String(),
                        DescriptionItemThree = c.String(),
                        CountItem = c.Int(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OtherStoreId)
                .ForeignKey("store.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            AddColumn("store.Hanging", "ItemId", c => c.Int(nullable: false));
            AddColumn("store.SMD", "ItemId", c => c.Int(nullable: false));
            AlterColumn("store.Hanging", "RatedItem", c => c.Int());
            AlterColumn("store.SMD", "RatedItem", c => c.Int());
            CreateIndex("store.Hanging", "ItemId");
            CreateIndex("store.SMD", "ItemId");
            AddForeignKey("store.Hanging", "ItemId", "store.Item", "ItemId", cascadeDelete: true);
            AddForeignKey("store.SMD", "ItemId", "store.Item", "ItemId", cascadeDelete: true);
            DropColumn("store.Hanging", "Item");
            DropColumn("store.SMD", "Item");
        }
        
        public override void Down()
        {
            AddColumn("store.SMD", "Item", c => c.Int(nullable: false));
            AddColumn("store.Hanging", "Item", c => c.Int(nullable: false));
            DropForeignKey("store.SMD", "ItemId", "store.Item");
            DropForeignKey("store.OtherStore", "ItemId", "store.Item");
            DropForeignKey("store.Hanging", "ItemId", "store.Item");
            DropIndex("store.SMD", new[] { "ItemId" });
            DropIndex("store.OtherStore", new[] { "ItemId" });
            DropIndex("store.Hanging", new[] { "ItemId" });
            AlterColumn("store.SMD", "RatedItem", c => c.Int(nullable: false));
            AlterColumn("store.Hanging", "RatedItem", c => c.Int(nullable: false));
            DropColumn("store.SMD", "ItemId");
            DropColumn("store.Hanging", "ItemId");
            DropTable("store.OtherStore");
            DropTable("store.Item");
        }
    }
}
