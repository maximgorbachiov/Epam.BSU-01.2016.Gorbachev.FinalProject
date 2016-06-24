namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Type_Of_Fields_TimeToPass_And_DateOfPass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PassedTests", "TimeToPass", c => c.String());
            AlterColumn("dbo.PassedTests", "DateOfPass", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PassedTests", "DateOfPass", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PassedTests", "TimeToPass", c => c.DateTime(nullable: false));
        }
    }
}
