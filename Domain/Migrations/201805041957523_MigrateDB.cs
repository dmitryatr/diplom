namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryUrl", c => c.String(nullable: false));
            AddColumn("dbo.Products", "CategoryID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "CategoryID");
            DropColumn("dbo.Categories", "CategoryUrl");
        }
    }
}
