namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Type_Of_TimeToPass_Field_In_PassedTest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PassedTests", "TimeToPass", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PassedTests", "TimeToPass", c => c.DateTime());
        }
    }
}
