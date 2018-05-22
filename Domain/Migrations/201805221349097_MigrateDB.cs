namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "UserID");
            AddForeignKey("dbo.Products", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UserID", "dbo.Users");
            DropIndex("dbo.Products", new[] { "UserID" });
            DropColumn("dbo.Products", "UserID");
        }
    }
}
