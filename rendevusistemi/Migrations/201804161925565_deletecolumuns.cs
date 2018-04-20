namespace rendevusistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecolumuns : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Emploies", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emploies", "DateTime", c => c.DateTime(nullable: false));
        }
    }
}
