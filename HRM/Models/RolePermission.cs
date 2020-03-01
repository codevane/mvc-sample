using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class RolePermission
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public Guid ModuleId { get; set; }

        public string PermissionName { get; set; }

        public bool Permission { get; set; }

        [NotMapped]
        public Module Module { get; set; }

    }
}