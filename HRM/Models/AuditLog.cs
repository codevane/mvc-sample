using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class AuditLog
    {
        public Guid Id { get; set; }
        public DateTime LogDateTime { get; set; }
        [MaxLength(128)]
        public string UserId { get; set; }        
        public int Action { get; set; }
        [MaxLength(1024)]
        public string ModuleName { get; set; }
        [MaxLength(1024)]
        public string SubModuleName { get; set; }
        [MaxLength(1024)]
        public string ActionFrom { get; set; }
        public string ActionMessage { get; set; }
    }
}