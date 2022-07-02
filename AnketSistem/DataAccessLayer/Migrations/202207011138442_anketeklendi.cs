namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anketeklendi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TAdmins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        KullaniciAd = c.String(),
                        Sifre = c.String(),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.TAnkets",
                c => new
                    {
                        AnketID = c.Int(nullable: false, identity: true),
                        AnketAd = c.String(),
                        AnketTip = c.String(),
                        SirketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnketID)
                .ForeignKey("dbo.TSirkets", t => t.SirketID, cascadeDelete: true)
                .Index(t => t.SirketID);
            
            CreateTable(
                "dbo.TSirkets",
                c => new
                    {
                        SirketID = c.Int(nullable: false, identity: true),
                        SirketAd = c.String(),
                        Mudur = c.String(),
                        Sifre = c.String(),
                    })
                .PrimaryKey(t => t.SirketID);
            
            CreateTable(
                "dbo.TPersonels",
                c => new
                    {
                        PersonelID = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(),
                        Sifre = c.String(),
                        SirketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelID)
                .ForeignKey("dbo.TSirkets", t => t.SirketID, cascadeDelete: true)
                .Index(t => t.SirketID);
            
            CreateTable(
                "dbo.TCevaps",
                c => new
                    {
                        CevapID = c.Int(nullable: false, identity: true),
                        CevapAd = c.String(),
                        PersonelID = c.Int(nullable: false),
                        SoruID = c.Int(),
                    })
                .PrimaryKey(t => t.CevapID)
                .ForeignKey("dbo.TPersonels", t => t.PersonelID, cascadeDelete: true)
                .ForeignKey("dbo.TSorus", t => t.SoruID)
                .Index(t => t.PersonelID)
                .Index(t => t.SoruID);
            
            CreateTable(
                "dbo.TSorus",
                c => new
                    {
                        SoruID = c.Int(nullable: false, identity: true),
                        SoruAd = c.String(),
                        AnketID = c.Int(),
                    })
                .PrimaryKey(t => t.SoruID)
                .ForeignKey("dbo.TAnkets", t => t.AnketID)
                .Index(t => t.AnketID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TPersonels", "SirketID", "dbo.TSirkets");
            DropForeignKey("dbo.TCevaps", "SoruID", "dbo.TSorus");
            DropForeignKey("dbo.TSorus", "AnketID", "dbo.TAnkets");
            DropForeignKey("dbo.TCevaps", "PersonelID", "dbo.TPersonels");
            DropForeignKey("dbo.TAnkets", "SirketID", "dbo.TSirkets");
            DropIndex("dbo.TSorus", new[] { "AnketID" });
            DropIndex("dbo.TCevaps", new[] { "SoruID" });
            DropIndex("dbo.TCevaps", new[] { "PersonelID" });
            DropIndex("dbo.TPersonels", new[] { "SirketID" });
            DropIndex("dbo.TAnkets", new[] { "SirketID" });
            DropTable("dbo.TSorus");
            DropTable("dbo.TCevaps");
            DropTable("dbo.TPersonels");
            DropTable("dbo.TSirkets");
            DropTable("dbo.TAnkets");
            DropTable("dbo.TAdmins");
        }
    }
}
