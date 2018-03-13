namespace rendevusistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IslemGruplaris",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GURUPADI = c.String(),
                        Islemler_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Islemlers", t => t.Islemler_ID)
                .Index(t => t.Islemler_ID);
            
            CreateTable(
                "dbo.Islemlers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AD = c.String(),
                        SIRANO = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Kisilers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AD = c.String(),
                        SOYAD = c.String(),
                        ADRES = c.String(),
                        TELEFON = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IslemGruplaris", "Islemler_ID", "dbo.Islemlers");
            DropIndex("dbo.IslemGruplaris", new[] { "Islemler_ID" });
            DropTable("dbo.Kisilers");
            DropTable("dbo.Islemlers");
            DropTable("dbo.IslemGruplaris");
        }
    }
}
