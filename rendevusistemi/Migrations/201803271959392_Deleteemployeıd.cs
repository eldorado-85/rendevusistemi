namespace rendevusistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deleteemployeıd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "EmployesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "EmployesId", c => c.Int(nullable: false));
        }
    }
}
