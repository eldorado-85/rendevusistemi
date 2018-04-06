namespace rendevusistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deletedeneme : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Emploies", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emploies", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
