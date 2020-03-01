using HRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HRM
{
    public class Utility
    {
        public static string SMTP_CONFIG_SECTION_NAME = "Smtp";
        public static string EMAIL_FROM_CONFIG_KEY_NAME = "EmailFrom";
        public static string ADMIN_EMAIL_CONFIG_KEY_NAME = "AdminEmailAddress";

        public static bool HasPermission(Guid userId, string moduleId, string permissionName)
        {
            bool result = false;

            // TODO: set permission 

            return result;
        }

        public static void WriteErrorLog(ErrorLog errorLog)
        {
            try
            {
                if (errorLog.ErrorMessage.Length > 1023)
                {
                    errorLog.ErrorMessage = errorLog.ErrorMessage.Substring(0, 1000);
                }
                using (HRMContext db = new HRMContext())
                {
                    errorLog.Id = Guid.NewGuid();
                    errorLog.CreateDate = DateTime.UtcNow;
                    db.ErrorLogs.Add(errorLog);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                using (var db = new HRMContext())
                {
                    var log = new ErrorLog();
                    log.Id = Guid.NewGuid();
                    log.CreateDate = DateTime.UtcNow;
                    log.ErrorFor = "Exception to write error log";
                    log.ErrorFrom = "WriteErrorLog";
                    log.ErrorMessage = ex.Message.Length > 1023 ? ex.Message.Substring(0, 1000) : ex.Message;
                    db.ErrorLogs.Add(log);
                    db.SaveChanges();
                }
            }
        }

        public async static Task WriteAuditLog(AuditLog auditLog)
        {
            try
            {                
                using (HRMContext db = new HRMContext())
                {
                    auditLog.Id = Guid.NewGuid();
                    auditLog.LogDateTime = DateTime.UtcNow;
                    db.AuditLogs.Add(auditLog);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog( new ErrorLog()
                {
                    ErrorFor = "Writing Audit Log",
                    ErrorFrom = "Utility.WriteAuditLog",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
        }
    }
}