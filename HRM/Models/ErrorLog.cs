using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class ErrorLog
    {
        public Guid Id { get; set; }
        [MaxLength(128)]
        public string userId { get; set; }
        public DateTime CreateDate { get; set; }
        [MaxLength(1024)]
        public string ErrorFrom { get; set; }
        [MaxLength(1024)]
        public string ErrorFor { get; set; }
        [MaxLength(1024)]
        public string ErrorMessage { get; set; }
    }
}