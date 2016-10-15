namespace PCB.NET.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            AddColumn("store.Board", "NameBlock", c => c.String(nullable: false));
            AddColumn("store.Board", "Make", c => c.String(nullable: false));
            AddColumn("store.HangingItem", "NameItem", c => c.String(nullable: false));
            AddColumn("store.SMDItem", "NameItem", c => c.String(nullable: false));
            AlterColumn("store.Hanging", "ValueItem", c => c.String());
            AlterColumn("store.Hanging", "DescriptionItem", c => c.String());
            AlterColumn("store.SMD", "ValueItem", c => c.String());
            AlterColumn("store.SMD", "DescriptionItem", c => c.String());
            DropColumn("store.Board", "Name");
            DropColumn("store.Item", "SMDId");
            DropColumn("store.Item", "HangingId");
            DropColumn("store.Item", "OtherStoreId");
        }
        
        public override void Down()
        {
            AddColumn("store.Item", "OtherStoreId", c => c.Int(nullable: false));
            AddColumn("store.Item", "HangingId", c => c.Int(nullable: false));
            AddColumn("store.Item", "SMDId", c => c.Int(nullable: false));
            AddColumn("store.Board", "Name", c => c.String(nullable: false));
            AlterColumn("store.SMD", "DescriptionItem", c => c.String(nullable: false));
            AlterColumn("store.SMD", "ValueItem", c => c.Double(nullable: false));
            AlterColumn("store.Hanging", "DescriptionItem", c => c.String(nullable: false));
            AlterColumn("store.Hanging", "ValueItem", c => c.Double(nullable: false));
            DropColumn("store.SMDItem", "NameItem");
            DropColumn("store.HangingItem", "NameItem");
            DropColumn("store.Board", "Make");
            DropColumn("store.Board", "NameBlock");
        }
    }
}
