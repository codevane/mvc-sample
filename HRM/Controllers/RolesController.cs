using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRM.Models;

namespace HRM.Controllers
{
    public class RolesController : Controller
    {
        private HRMContext db = new HRMContext();

        // GET: Roles
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Roles/Permissions/5
        [Route("Permissions/{id}")]
        public ActionResult Permissions(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Role role = db.Roles.Find(id);
            role.RolePermissions = db.RolePermissions.Where(rp => rp.RoleId == id).ToList();
            role.RolePermissions.ForEach(p => p.Module = db.Modules.First(m => m.Id == p.ModuleId));
            role.RolePermissions = role.RolePermissions.OrderBy(m => m.Module.Name).ToList();

            if (role == null)
            {
                return HttpNotFound();
            }

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Permissions(List<RolePermission> rolePermissions)
        {
            //if (ModelState.IsValid)
            //{
            //    role.Id = Guid.NewGuid();
            //    db.Roles.Add(role);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            // TODO: save Roles Permission

            if(rolePermissions != null && rolePermissions.Count() > 0)
            {
                return RedirectToAction("Permission", new { id = rolePermissions[0].RoleId });
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }


        // GET: Roles/Permissions/5
        [Route("Users/{id}")]
        public ActionResult Users(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Role role = db.Roles.Find(id);
            role.RoleUsers = db.RoleUsers.Where(rp => rp.RoleId == id).ToList();
            role.RoleUsers.ForEach(p => p.User = db.Users.First(m => m.Id == p.UserId));
            

            if (role == null)
            {
                return HttpNotFound();
            }

            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,ActiveStatus")] Role role)
        {
            if (ModelState.IsValid)
            {
                role.Id = Guid.NewGuid();
                db.Roles.Add(role);
                db.SaveChanges();
                using (var insertDb = new HRMContext())
                {
                    RolePermission rolePermission = new RolePermission();

                    insertDb.RolePermissions.RemoveRange(db.RolePermissions.Where(r=>r.RoleId==role.Id));

                    db.ModulePermissions.ToList().ForEach(mp =>
                    {

                        rolePermission = new RolePermission()
                        {
                            Id = Guid.NewGuid(),
                            RoleId = role.Id,
                            ModuleId = mp.ModuleId,
                            PermissionName = mp.PermissionName,
                            Permission = false
                        };
                        insertDb.RolePermissions.Add(rolePermission);

                    });
                    insertDb.SaveChanges();
                }              

                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ActiveStatus")] Role role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Role role = db.Roles.Find(id);
            db.Roles.Remove(role);
            db.SaveChanges();
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
