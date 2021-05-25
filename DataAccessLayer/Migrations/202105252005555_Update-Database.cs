namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryDescription", c => c.String(maxLength: 500));
            DropColumn("dbo.Categories", "CategoryDescriotion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "CategoryDescriotion", c => c.String(maxLength: 500));
            DropColumn("dbo.Categories", "CategoryDescription");
        }
    }
}
