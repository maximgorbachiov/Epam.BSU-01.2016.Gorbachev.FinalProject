namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPassedTests : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClientTests", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.ClientTests", "Test_Id", "dbo.Tests");
            DropIndex("dbo.ClientTests", new[] { "Client_Id" });
            DropIndex("dbo.ClientTests", new[] { "Test_Id" });
            CreateTable(
                "dbo.PassedTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeToPass = c.DateTime(nullable: false),
                        CountOfRightAnswer = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId)
                .Index(t => t.ClientId);
            
            DropTable("dbo.ClientTests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClientTests",
                c => new
                    {
                        Client_Id = c.Int(nullable: false),
                        Test_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Client_Id, t.Test_Id });
            
            DropForeignKey("dbo.PassedTests", "TestId", "dbo.Tests");
            DropForeignKey("dbo.PassedTests", "ClientId", "dbo.Clients");
            DropIndex("dbo.PassedTests", new[] { "ClientId" });
            DropIndex("dbo.PassedTests", new[] { "TestId" });
            DropTable("dbo.PassedTests");
            CreateIndex("dbo.ClientTests", "Test_Id");
            CreateIndex("dbo.ClientTests", "Client_Id");
            AddForeignKey("dbo.ClientTests", "Test_Id", "dbo.Tests", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClientTests", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
