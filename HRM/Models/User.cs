using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class User
    {
        public Guid Id { get; set; }
               
        [MaxLength(68)]
        public string loginId { get; set; }

        [MaxLength(68)]
        public string Password { get; set; }

        public bool ActiveStatus { get; set; }
    }
}