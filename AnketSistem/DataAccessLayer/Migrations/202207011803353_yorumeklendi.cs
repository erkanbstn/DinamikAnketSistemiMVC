namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yorumeklendi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TYorums",
                c => new
                    {
                        YorumID = c.Int(nullable: false, identity: true),
                        YorumAd = c.String(),
                        PersonelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.YorumID)
                .ForeignKey("dbo.TPersonels", t => t.PersonelID, cascadeDelete: true)
                .Index(t => t.PersonelID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TYorums", "PersonelID", "dbo.TPersonels");
            DropIndex("dbo.TYorums", new[] { "PersonelID" });
            DropTable("dbo.TYorums");
        }
    }
}
