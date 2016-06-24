namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Type_Of_RightAnswer_Field_In_Question : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "RightAnswer", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "RightAnswer", c => c.Int(nullable: false));
        }
    }
}
