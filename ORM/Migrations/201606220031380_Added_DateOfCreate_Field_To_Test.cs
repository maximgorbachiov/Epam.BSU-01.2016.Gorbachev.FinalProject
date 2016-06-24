namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_DateOfCreate_Field_To_Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "DateOfCreate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "DateOfCreate");
        }
    }
}
