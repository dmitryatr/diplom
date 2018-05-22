namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Type", c => c.String());
            AddColumn("dbo.Products", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "City");
            DropColumn("dbo.Products", "Type");
        }
    }
}
