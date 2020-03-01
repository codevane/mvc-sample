using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class HRMContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public HRMContext() : base("name=HRMContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        public DbSet<Module> Modules { get; set; }
        public DbSet<ModulePermission> ModulePermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
