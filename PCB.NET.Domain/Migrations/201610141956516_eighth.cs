namespace PCB.NET.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eighth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("store.Size", "SizeId", "store.Hanging");
            DropForeignKey("store.Packages", "PackagesId", "store.SMD");
            DropIndex("store.Packages", new[] { "PackagesId" });
            DropIndex("store.Size", new[] { "SizeId" });
            DropPrimaryKey("store.Packages");
            DropPrimaryKey("store.Size");
            AlterColumn("store.Packages", "PackagesId", c => c.Int(nullable: false, identity: true));
            AlterColumn("store.Size", "SizeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("store.Packages", "PackagesId");
            AddPrimaryKey("store.Size", "SizeId");
            CreateIndex("store.Hanging", "SizeId");
            CreateIndex("store.SMD", "PackagesId");
            AddForeignKey("store.Hanging", "SizeId", "store.Size", "SizeId", cascadeDelete: true);
            AddForeignKey("store.SMD", "PackagesId", "store.Packages", "PackagesId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("store.SMD", "PackagesId", "store.Packages");
            DropForeignKey("store.Hanging", "SizeId", "store.Size");
            DropIndex("store.SMD", new[] { "PackagesId" });
            DropIndex("store.Hanging", new[] { "SizeId" });
            DropPrimaryKey("store.Size");
            DropPrimaryKey("store.Packages");
            AlterColumn("store.Size", "SizeId", c => c.Int(nullable: false));
            AlterColumn("store.Packages", "PackagesId", c => c.Int(nullable: false));
            AddPrimaryKey("store.Size", "SizeId");
            AddPrimaryKey("store.Packages", "PackagesId");
            CreateIndex("store.Size", "SizeId");
            CreateIndex("store.Packages", "PackagesId");
            AddForeignKey("store.Packages", "PackagesId", "store.SMD", "SMDId");
            AddForeignKey("store.Size", "SizeId", "store.Hanging", "HangingId");
        }
    }
}
