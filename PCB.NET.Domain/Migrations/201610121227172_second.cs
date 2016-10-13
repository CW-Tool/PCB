namespace PCB.NET.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("store.SMD", "Packages_PackagesId", "store.Packages");
            DropIndex("store.SMD", new[] { "Packages_PackagesId" });
            RenameColumn(table: "store.SMD", name: "Packages_PackagesId", newName: "PackagesId");
            CreateTable(
                "machine.Dvc",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TimeSecond = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("store.Board", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "machine.Ebso",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TimeSecond = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("store.Board", t => t.Id)
                .Index(t => t.Id);
            
            AlterColumn("store.SMD", "PackagesId", c => c.Int(nullable: false));
            CreateIndex("store.SMD", "PackagesId");
            AddForeignKey("store.SMD", "PackagesId", "store.Packages", "PackagesId", cascadeDelete: true);
            DropColumn("store.SMD", "PackageId");
        }
        
        public override void Down()
        {
            AddColumn("store.SMD", "PackageId", c => c.Int(nullable: false));
            DropForeignKey("store.SMD", "PackagesId", "store.Packages");
            DropForeignKey("machine.Ebso", "Id", "store.Board");
            DropForeignKey("machine.Dvc", "Id", "store.Board");
            DropIndex("store.SMD", new[] { "PackagesId" });
            DropIndex("machine.Ebso", new[] { "Id" });
            DropIndex("machine.Dvc", new[] { "Id" });
            AlterColumn("store.SMD", "PackagesId", c => c.Int());
            DropTable("machine.Ebso");
            DropTable("machine.Dvc");
            RenameColumn(table: "store.SMD", name: "PackagesId", newName: "Packages_PackagesId");
            CreateIndex("store.SMD", "Packages_PackagesId");
            AddForeignKey("store.SMD", "Packages_PackagesId", "store.Packages", "PackagesId");
        }
    }
}
