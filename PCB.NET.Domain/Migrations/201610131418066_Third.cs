namespace PCB.NET.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("store.Hanging", "SizeId", "store.Size");
            DropForeignKey("store.SMD", "PackagesId", "store.Packages");
            DropIndex("store.Hanging", new[] { "SizeId" });
            DropIndex("store.SMD", new[] { "PackagesId" });
            DropPrimaryKey("store.Size");
            DropPrimaryKey("store.Packages");
            CreateTable(
                "plan.MapBoard",
                c => new
                    {
                        SingleMapBoardId = c.Int(nullable: false, identity: true),
                        CountBoard = c.Int(nullable: false),
                        CountHanging = c.Int(nullable: false),
                        CountDvc = c.Int(nullable: false),
                        CountEbso = c.Int(nullable: false),
                        CountPreComplete = c.Int(nullable: false),
                        CountReadyDone = c.Int(nullable: false),
                        BoardId = c.Int(nullable: false),
                        MapId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SingleMapBoardId)
                .ForeignKey("store.Board", t => t.BoardId, cascadeDelete: true)
                .ForeignKey("plan.Map", t => t.MapId, cascadeDelete: true)
                .Index(t => t.BoardId)
                .Index(t => t.MapId);
            
            CreateTable(
                "plan.Map",
                c => new
                    {
                        MapId = c.Int(nullable: false, identity: true),
                        Date = c.Int(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MapId);
            
            AlterColumn("store.Size", "SizeId", c => c.Int(nullable: false));
            AlterColumn("store.Packages", "PackagesId", c => c.Int(nullable: false));
            AddPrimaryKey("store.Size", "SizeId");
            AddPrimaryKey("store.Packages", "PackagesId");
            CreateIndex("store.Size", "SizeId");
            CreateIndex("store.Packages", "PackagesId");
            AddForeignKey("store.Size", "SizeId", "store.Hanging", "HangingId");
            AddForeignKey("store.Packages", "PackagesId", "store.SMD", "SMDId");
            DropColumn("employee.Worker", "PositionId");
        }
        
        public override void Down()
        {
            AddColumn("employee.Worker", "PositionId", c => c.Int(nullable: false));
            DropForeignKey("store.Packages", "PackagesId", "store.SMD");
            DropForeignKey("store.Size", "SizeId", "store.Hanging");
            DropForeignKey("plan.MapBoard", "MapId", "plan.Map");
            DropForeignKey("plan.MapBoard", "BoardId", "store.Board");
            DropIndex("store.Packages", new[] { "PackagesId" });
            DropIndex("plan.MapBoard", new[] { "MapId" });
            DropIndex("plan.MapBoard", new[] { "BoardId" });
            DropIndex("store.Size", new[] { "SizeId" });
            DropPrimaryKey("store.Packages");
            DropPrimaryKey("store.Size");
            AlterColumn("store.Packages", "PackagesId", c => c.Int(nullable: false, identity: true));
            AlterColumn("store.Size", "SizeId", c => c.Int(nullable: false, identity: true));
            DropTable("plan.Map");
            DropTable("plan.MapBoard");
            AddPrimaryKey("store.Packages", "PackagesId");
            AddPrimaryKey("store.Size", "SizeId");
            CreateIndex("store.SMD", "PackagesId");
            CreateIndex("store.Hanging", "SizeId");
            AddForeignKey("store.SMD", "PackagesId", "store.Packages", "PackagesId", cascadeDelete: true);
            AddForeignKey("store.Hanging", "SizeId", "store.Size", "SizeId", cascadeDelete: true);
        }
    }
}
