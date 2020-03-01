using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class Module
    {
        public Guid Id { get; set; }

        [MaxLength(68)]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        public bool ActiveStatus { get; set; }


    }
}