namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        City = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Categories", "ParentID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "ParentID", c => c.Int(nullable: false));
            DropTable("dbo.Users");
        }
    }
}
