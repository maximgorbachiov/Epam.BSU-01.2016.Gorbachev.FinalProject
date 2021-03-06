namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Image_To_Question : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Image");
        }
    }
}
