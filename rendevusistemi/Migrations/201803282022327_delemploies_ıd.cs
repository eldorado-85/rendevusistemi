namespace rendevusistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delemploies_ıd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Emloiess_Id", "dbo.Emploies");
            DropIndex("dbo.Appointments", new[] { "Emloiess_Id" });
            DropColumn("dbo.Appointments", "Emloiess_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Emloiess_Id", c => c.Int());
            CreateIndex("dbo.Appointments", "Emloiess_Id");
            AddForeignKey("dbo.Appointments", "Emloiess_Id", "dbo.Emploies", "Id");
        }
    }
}
