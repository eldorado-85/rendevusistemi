namespace rendevusistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jobs", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "LastName", c => c.String());
        }
    }
}
