namespace PCB.NET.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ninth1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("employee.Worker", "PositionId", "employee.Position");
            DropPrimaryKey("employee.Position");
            AddColumn("employee.Position", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("employee.Position", "PositionEmp", c => c.String(nullable: false));
            AddPrimaryKey("employee.Position", "Id");
            AddForeignKey("employee.Worker", "PositionId", "employee.Position", "Id", cascadeDelete: true);
            DropColumn("employee.Position", "PositionId");
            DropColumn("employee.Position", "PositionEmployee");
        }
        
        public override void Down()
        {
            AddColumn("employee.Position", "PositionEmployee", c => c.String());
            AddColumn("employee.Position", "PositionId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("employee.Worker", "PositionId", "employee.Position");
            DropPrimaryKey("employee.Position");
            DropColumn("employee.Position", "PositionEmp");
            DropColumn("employee.Position", "Id");
            AddPrimaryKey("employee.Position", "PositionId");
            AddForeignKey("employee.Worker", "PositionId", "employee.Position", "PositionId", cascadeDelete: true);
        }
    }
}
