namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "CategoryPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "CategoryPath", c => c.String());
        }
    }
}
