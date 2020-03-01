using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string No { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(128)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string Sex { get; set; }

        [MaxLength(1024)]
        public string Address { get; set; }

        [MaxLength(10)]
        public string BloodGroup { get; set; }

        public DateTime BirthDay { get; set; }
    }
}