using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class ModulePermission
    {
        public Guid Id { get; set; }

        public Guid ModuleId { get; set; }

        /// <summary>
        /// Permission Name (Fixed name) 
        /// like -  READ CREATE UPDATE DELETE .. 
        /// </summary>
        public string PermissionName { get; set; }

        /// <summary>
        /// Sequence number for display in UI
        /// </summary>
        public int Sequence { get; set; }
    }
}