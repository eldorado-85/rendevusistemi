namespace rendevusistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addupdatedatabase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "MyProperty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "MyProperty");
        }
    }
}
