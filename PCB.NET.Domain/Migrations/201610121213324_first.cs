namespace PCB.NET.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "store.Board",
                c => new
                    {
                        BoardId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CountBoard = c.Int(nullable: false),
                        Description = c.String(),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BoardId);
            
            CreateTable(
                "employee.DoneWork",
                c => new
                    {
                        DoneId = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        BoardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoneId)
                .ForeignKey("store.Board", t => t.BoardId, cascadeDelete: true)
                .ForeignKey("employee.Worker", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.BoardId);
            
            CreateTable(
                "employee.Worker",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MidName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DailyWorkComplete = c.DateTime(nullable: false),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "employee.Position",
                c => new
                    {
                        PositionId = c.Int(nullable: false),
                        PositionEmployee = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId)
                .ForeignKey("employee.Worker", t => t.PositionId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "store.HangingItem",
                c => new
                    {
                        HangingItemId = c.Int(nullable: false, identity: true),
                        HangingId = c.Int(nullable: false),
                        BoardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HangingItemId)
                .ForeignKey("store.Board", t => t.BoardId, cascadeDelete: true)
                .ForeignKey("store.Hanging", t => t.HangingId, cascadeDelete: true)
                .Index(t => t.HangingId)
                .Index(t => t.BoardId);
            
            CreateTable(
                "store.Hanging",
                c => new
                    {
                        HangingId = c.Int(nullable: false, identity: true),
                        Item = c.Int(nullable: false),
                        ValueItem = c.Double(nullable: false),
                        RatedItem = c.Int(nullable: false),
                        DescriptionItem = c.String(nullable: false),
                        CountItem = c.Int(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        SizeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HangingId)
                .ForeignKey("store.Size", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.SizeId);
            
            CreateTable(
                "store.Size",
                c => new
                    {
                        SizeId = c.Int(nullable: false, identity: true),
                        Sizes = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SizeId);
            
            CreateTable(
                "store.SMDItem",
                c => new
                    {
                        SMDItemId = c.Int(nullable: false, identity: true),
                        BoardId = c.Int(nullable: false),
                        SmdId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SMDItemId)
                .ForeignKey("store.Board", t => t.BoardId, cascadeDelete: true)
                .ForeignKey("store.SMD", t => t.SmdId, cascadeDelete: true)
                .Index(t => t.BoardId)
                .Index(t => t.SmdId);
            
            CreateTable(
                "store.SMD",
                c => new
                    {
                        SMDId = c.Int(nullable: false, identity: true),
                        Item = c.Int(nullable: false),
                        ValueItem = c.Double(nullable: false),
                        RatedItem = c.Int(nullable: false),
                        DescriptionItem = c.String(nullable: false),
                        Feeder = c.Int(nullable: false),
                        CountItem = c.Int(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        PackageId = c.Int(nullable: false),
                        Packages_PackagesId = c.Int(),
                    })
                .PrimaryKey(t => t.SMDId)
                .ForeignKey("store.Packages", t => t.Packages_PackagesId)
                .Index(t => t.Packages_PackagesId);
            
            CreateTable(
                "store.Packages",
                c => new
                    {
                        PackagesId = c.Int(nullable: false, identity: true),
                        Packs = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PackagesId);
            
            CreateTable(
                "store.GasBalloon",
                c => new
                    {
                        GasBalloonId = c.Int(nullable: false, identity: true),
                        BalloonNumber = c.String(nullable: false),
                        DateNextModified = c.String(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GasBalloonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("store.SMDItem", "SmdId", "store.SMD");
            DropForeignKey("store.SMD", "Packages_PackagesId", "store.Packages");
            DropForeignKey("store.SMDItem", "BoardId", "store.Board");
            DropForeignKey("store.Hanging", "SizeId", "store.Size");
            DropForeignKey("store.HangingItem", "HangingId", "store.Hanging");
            DropForeignKey("store.HangingItem", "BoardId", "store.Board");
            DropForeignKey("employee.Position", "PositionId", "employee.Worker");
            DropForeignKey("employee.DoneWork", "EmployeeId", "employee.Worker");
            DropForeignKey("employee.DoneWork", "BoardId", "store.Board");
            DropIndex("store.SMD", new[] { "Packages_PackagesId" });
            DropIndex("store.SMDItem", new[] { "SmdId" });
            DropIndex("store.SMDItem", new[] { "BoardId" });
            DropIndex("store.Hanging", new[] { "SizeId" });
            DropIndex("store.HangingItem", new[] { "BoardId" });
            DropIndex("store.HangingItem", new[] { "HangingId" });
            DropIndex("employee.Position", new[] { "PositionId" });
            DropIndex("employee.DoneWork", new[] { "BoardId" });
            DropIndex("employee.DoneWork", new[] { "EmployeeId" });
            DropTable("store.GasBalloon");
            DropTable("store.Packages");
            DropTable("store.SMD");
            DropTable("store.SMDItem");
            DropTable("store.Size");
            DropTable("store.Hanging");
            DropTable("store.HangingItem");
            DropTable("employee.Position");
            DropTable("employee.Worker");
            DropTable("employee.DoneWork");
            DropTable("store.Board");
        }
    }
}
