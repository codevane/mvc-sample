using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class EmailContact
    {
        public Guid Id { get; set; }
               
        public string Name { get; set; }
                
        public string Email { get; set; }
                
        public string ContactNo { get; set; }

        public string Descrition { get; set; }
    }
}