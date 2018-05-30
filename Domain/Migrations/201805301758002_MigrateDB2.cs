namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImagesName", c => c.String());
            DropColumn("dbo.Products", "ImageData");
            DropColumn("dbo.Products", "ImageMimeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImageMimeType", c => c.String());
            AddColumn("dbo.Products", "ImageData", c => c.Binary());
            DropColumn("dbo.Products", "ImagesName");
        }
    }
}
