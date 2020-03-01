using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class RoleUser
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public Guid UserId { get; set; }

        [NotMapped]
        public User User { get; set; }
    }
}