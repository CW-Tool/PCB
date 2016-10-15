namespace PCB.NET.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("employee.Position", "PositionId", "employee.Worker");
            DropIndex("employee.Position", new[] { "PositionId" });
            DropPrimaryKey("employee.Position");
            AddColumn("employee.Worker", "PositionId", c => c.Int(nullable: false));
            AlterColumn("employee.Position", "PositionId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("employee.Position", "PositionId");
            CreateIndex("employee.Worker", "PositionId");
            AddForeignKey("employee.Worker", "PositionId", "employee.Position", "PositionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("employee.Worker", "PositionId", "employee.Position");
            DropIndex("employee.Worker", new[] { "PositionId" });
            DropPrimaryKey("employee.Position");
            AlterColumn("employee.Position", "PositionId", c => c.Int(nullable: false));
            DropColumn("employee.Worker", "PositionId");
            AddPrimaryKey("employee.Position", "PositionId");
            CreateIndex("employee.Position", "PositionId");
            AddForeignKey("employee.Position", "PositionId", "employee.Worker", "Id");
        }
    }
}
