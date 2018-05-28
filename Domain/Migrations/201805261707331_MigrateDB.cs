namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "RoleID", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "RoleID");
            AddForeignKey("dbo.Users", "RoleID", "dbo.Roles", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropColumn("dbo.Users", "RoleID");
            DropTable("dbo.Roles");
        }
    }
}
