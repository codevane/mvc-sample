using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class Role
    {
        public Guid Id { get; set; }

        [MaxLength(68)]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        public bool ActiveStatus { get; set; }

        [NotMapped]
        public List<RolePermission> RolePermissions { get; set; }

        [NotMapped]
        public List<RoleUser> RoleUsers { get; set; }



    }
}