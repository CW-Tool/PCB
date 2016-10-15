namespace PCB.NET.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ninth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("employee.Position", "PositionEmployee", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("employee.Position", "PositionEmployee", c => c.String(nullable: false));
        }
    }
}
