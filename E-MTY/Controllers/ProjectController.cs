using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_MTY.Data;

namespace E_MTY.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectEntities db = new ProjectEntities();
        private BusinessEntities dbB = new BusinessEntities();

        // GET: Project
        public ActionResult Index()
        {
            return View(db.AspNetProjects.ToList());
        }

        // GET: Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetProject aspNetProject = db.AspNetProjects.Find(id);
            if (aspNetProject == null)
            {
                return HttpNotFound();
            }
            return View(aspNetProject);
        }

        // GET: Project/Create
        public ActionResult Create(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusinessId,Name,Description,Preview")] AspNetProject aspNetProject)
        {
            if (ModelState.IsValid)
            {
                db.AspNetProjects.Add(aspNetProject);
                db.SaveChanges();
                return RedirectToAction("MyProjects");
            }

            return View(aspNetProject);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetProject aspNetProject = db.AspNetProjects.Find(id);
            if (aspNetProject == null)
            {
                return HttpNotFound();
            }
            return View(aspNetProject);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PojectId,BusinessId,Name,Description,Preview")] AspNetProject aspNetProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspNetProject);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetProject aspNetProject = db.AspNetProjects.Find(id);
            if (aspNetProject == null)
            {
                return HttpNotFound();
            }
            return View(aspNetProject);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AspNetProject aspNetProject = db.AspNetProjects.Find(id);
            db.AspNetProjects.Remove(aspNetProject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MyProjects()
        {

            var tupleModel = new Tuple<List<AspNetProject>, List<AspNetBusiness>>(db.AspNetProjects.ToList(), dbB.AspNetBusinesses.ToList());
            return View(tupleModel);
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
