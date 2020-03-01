using HRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRM.Common;
using System.Data.SqlClient;

namespace HRM.Controllers
{
    public class HomeController : Controller
    {
        private HRMContext db = new HRMContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {           
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(EmailContact emailContact)
        {
            // Example of 
            // Send Email notification

            bool result = NotificationService.SendContactUsEmail(emailContact);
            if (result)
            {
                return RedirectToAction("Contact");
            }
          
            return View(emailContact);
        }

        public ActionResult Auditlog()
        {
            Guid userId = Guid.Empty;

            if (!Utility.HasPermission(userId,"","READ"))
            {
                return RedirectToAction("Error", new { message="has no permission!!"});
            }
            // Example of 
            // Calling Stored Procedure
            // procName Proc_auditlogs
            // param @action            
            string procedureName = "Proc_auditlogs @action, @moduleName";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@action", "1"));
            parameters.Add(new SqlParameter("@moduleName", "Employee"));

            List<AuditLog> auditLogs = db.Database.SqlQuery<AuditLog>(procedureName, parameters.ToArray()).ToList();

            return View(auditLogs);
        }


        public ActionResult Error(string message)
        {
            ViewBag.Message = message !=""? message : "Error details is here!!";
            return View();
        }



    }
}