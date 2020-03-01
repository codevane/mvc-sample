namespace HRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HRMContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModulePermissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ModuleId = c.Guid(nullable: false),
                        PermissionName = c.String(),
                        Sequence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 68),
                        Description = c.String(maxLength: 512),
                        ActiveStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RolePermissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        ModuleId = c.Guid(nullable: false),
                        PermissionName = c.String(),
                        Permission = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 68),
                        Description = c.String(maxLength: 512),
                        ActiveStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        loginId = c.String(maxLength: 68),
                        Password = c.String(maxLength: 68),
                        ActiveStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.RoleUsers");
            DropTable("dbo.Roles");
            DropTable("dbo.RolePermissions");
            DropTable("dbo.Modules");
            DropTable("dbo.ModulePermissions");
        }
    }
}
