namespace PCB.NET.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenth : DbMigration
    {
        public override void Up()
        {
            AddColumn("employee.Worker", "DescriptionWorker", c => c.String());
            DropColumn("employee.Worker", "DailyWorkComplete");
        }
        
        public override void Down()
        {
            AddColumn("employee.Worker", "DailyWorkComplete", c => c.DateTime(nullable: false));
            DropColumn("employee.Worker", "DescriptionWorker");
        }
    }
}
