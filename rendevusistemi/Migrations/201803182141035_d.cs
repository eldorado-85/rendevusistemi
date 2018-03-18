namespace rendevusistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emploies", "Number", c => c.Int(nullable: false));
            DropColumn("dbo.Emploies", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emploies", "Phone", c => c.Int(nullable: false));
            DropColumn("dbo.Emploies", "Number");
        }
    }
}
