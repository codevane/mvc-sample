using HRM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRM.Repositories
{
    public class HRMRepository
    {
        public IEnumerable<T> GetData<T>(DbContext db, string query)
        {
            List<T> results = new List<T>();
            try
            {
                results = db.Database.SqlQuery<T>(query).ToList();
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "Executing Query",
                    ErrorFrom = "HRMRepository.GetData",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
            return results;
        }
    }
}