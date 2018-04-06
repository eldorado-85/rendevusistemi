namespace rendevusistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addemployeıd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "EmployeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "EmployeId");
        }
    }
}
