using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRM.Common.Enums;
using HRM.Models;

namespace HRM.Controllers
{
    public class EmployeesController : Controller
    {
        private HRMContext db = new HRMContext();

        // GET: Employees
        public ActionResult Index()
        {
            // Example of 
            // SQL query Execution 

            string query = "Select * from Employees ";
            List<Employee> employees = db.Database.SqlQuery<Employee>(query).ToList();
            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,No,Name,Email,Sex,Address,BloodGroup,BirthDay")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = Guid.NewGuid();
                //db.Employees.Add(employee);
                //db.SaveChanges();

                //// Example of 
                //// Audit Logs
                //Utility.WriteAuditLog(new AuditLog() {
                //    ActionFrom = "EmployeesController.Create",
                //    Action = (int)AuditAction.Add,
                //    ModuleName = "", // Module name
                //    SubModuleName ="", // Sub module name if any
                //    UserId = "", // Id from Current User
                //    ActionMessage ="" // Message if any
                //});


                // CREATE by SP call
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection(db.Database.Connection.ConnectionString);
                    SqlCommand cmd = new SqlCommand("Proc_insert_emp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", employee.Id);
                    cmd.Parameters.AddWithValue("@No", employee.No);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Sex", employee.Sex);
                    cmd.Parameters.AddWithValue("@Address", employee.Address);
                    cmd.Parameters.AddWithValue("@BloodGroup", employee.BloodGroup);
                    cmd.Parameters.AddWithValue("@BirthDay", employee.BirthDay);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Utility.WriteErrorLog(new ErrorLog()
                    {
                        ErrorFor = "Create Employee by SP",
                        ErrorFrom = "EmployeesController.Create",
                        ErrorMessage = "Exception: " + ex.Message
                    });
                }
                finally
                {
                    con.Close();
                }

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,No,Name,Email,Sex,Address,BloodGroup,BirthDay")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Example of
                // Error Log
                //try
                //{
                //    db.Entry(employee).State = EntityState.Modified;
                //    db.SaveChanges();
                //}
                //catch (Exception ex)
                //{
                //    Utility.WriteErrorLog(new ErrorLog()
                //    {
                //        ErrorFor = "Edit Employee",
                //        ErrorFrom = "EmployeesController.Edit",
                //        ErrorMessage = "Exception: " + ex.Message
                //    });
                //}

                // EDIT by SP call
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection(db.Database.Connection.ConnectionString);
                    SqlCommand cmd = new SqlCommand("Proc_update_emp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", employee.Id);
                    cmd.Parameters.AddWithValue("@No", employee.No);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Sex", employee.Sex);
                    cmd.Parameters.AddWithValue("@Address", employee.Address);
                    cmd.Parameters.AddWithValue("@BloodGroup", employee.BloodGroup);
                    cmd.Parameters.AddWithValue("@BirthDay", employee.BirthDay);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Utility.WriteErrorLog(new ErrorLog()
                    {
                        ErrorFor = "Edit Employee by SP",
                        ErrorFrom = "EmployeesController.Edit",
                        ErrorMessage = "Exception: " + ex.Message
                    });
                }
                finally
                {
                    con.Close();
                }

                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Employee employee = db.Employees.Find(id);
            //db.Employees.Remove(employee);
            //db.SaveChanges();

            // Delete by SP call
            SqlConnection con = null;           
            try
            {
                con = new SqlConnection(db.Database.Connection.ConnectionString);
                SqlCommand cmd = new SqlCommand("Proc_delete_emp", con);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@Id", employee.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "Delete Employee by SP",
                    ErrorFrom = "EmployeesController.DeleteConfirmed",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
            finally
            {
                con.Close();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
