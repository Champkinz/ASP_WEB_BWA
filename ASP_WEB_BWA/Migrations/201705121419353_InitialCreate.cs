namespace ASP_WEB_BWA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestRvs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        ResID = c.Int(nullable: false),
                        Test_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id)
                .Index(t => t.Test_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestRvs", "Test_Id", "dbo.Tests");
            DropIndex("dbo.TestRvs", new[] { "Test_Id" });
            DropTable("dbo.TestRvs");
            DropTable("dbo.Tests");
        }
    }
}
