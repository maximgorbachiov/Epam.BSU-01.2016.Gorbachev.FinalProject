namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Type_To_DateTime_In_TimeToPass_And_DateOfPass_In_PassedTest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PassedTests", "TimeToPass", c => c.DateTime());
            AlterColumn("dbo.PassedTests", "DateOfPass", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PassedTests", "DateOfPass", c => c.String());
            AlterColumn("dbo.PassedTests", "TimeToPass", c => c.String());
        }
    }
}
