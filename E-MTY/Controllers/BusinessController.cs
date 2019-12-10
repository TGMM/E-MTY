using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_MTY.Data;
using Microsoft.AspNet.Identity;

namespace E_MTY.Controllers
{
    public class BusinessController : Controller
    {
        private BusinessEntities db = new BusinessEntities();

        // GET: Business
        public ActionResult Index()
        {
            return View(db.AspNetBusinesses.ToList());
        }

        // GET: Business/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetBusiness aspNetBusiness = db.AspNetBusinesses.Find(id);
            if (aspNetBusiness == null)
            {
                return HttpNotFound();
            }
            return View(aspNetBusiness);
        }

        // GET: Business/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Business/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Value,Address")] AspNetBusiness aspNetBusiness)
        {
            if (ModelState.IsValid)
            {
                db.AspNetBusinesses.Add(aspNetBusiness);
                db.AspNetBusinessUsers.Add(new AspNetBusinessUser
                {
                    UserId = User.Identity.GetUserId(),
                    BusinessId = aspNetBusiness.id
                });
                db.SaveChanges();
                return RedirectToAction("/Details/" + aspNetBusiness.id);
            }

            return View(aspNetBusiness);
        }

        // GET: Business/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetBusiness aspNetBusiness = db.AspNetBusinesses.Find(id);
            if (aspNetBusiness == null)
            {
                return HttpNotFound();
            }
            return View(aspNetBusiness);
        }

        // POST: Business/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Value,Address")] AspNetBusiness aspNetBusiness)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetBusiness).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspNetBusiness);
        }

        // GET: Business/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetBusiness aspNetBusiness = db.AspNetBusinesses.Find(id);
            if (aspNetBusiness == null)
            {
                return HttpNotFound();
            }
            return View(aspNetBusiness);
        }

        // POST: Business/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AspNetBusiness aspNetBusiness = db.AspNetBusinesses.Find(id);
            db.AspNetBusinesses.Remove(aspNetBusiness);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BusinessList()
        {
            return View(db.AspNetBusinesses.ToList());
        }

        public ActionResult MyBusinesses()
        {
            return View(db.AspNetBusinesses.ToList());
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
