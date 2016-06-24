namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateOfPassAddedToPassedTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PassedTests", "DateOfPass", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PassedTests", "DateOfPass");
        }
    }
}
