using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_MTY.Data;

namespace E_MTY.Controllers
{
    public class CourseController : Controller
    {
        private CourseEntities db = new CourseEntities();

        // GET: Course
        public ActionResult Index()
        {
            return View(db.AspNetCourses.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetCourse aspNetCourse = db.AspNetCourses.Find(id);
            if (aspNetCourse == null)
            {
                return HttpNotFound();
            }
            return View(aspNetCourse);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Date,Description")] AspNetCourse aspNetCourse)
        {
            if (ModelState.IsValid)
            {
                db.AspNetCourses.Add(aspNetCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aspNetCourse);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetCourse aspNetCourse = db.AspNetCourses.Find(id);
            if (aspNetCourse == null)
            {
                return HttpNotFound();
            }
            return View(aspNetCourse);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Date,Description")] AspNetCourse aspNetCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspNetCourse);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetCourse aspNetCourse = db.AspNetCourses.Find(id);
            if (aspNetCourse == null)
            {
                return HttpNotFound();
            }
            return View(aspNetCourse);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AspNetCourse aspNetCourse = db.AspNetCourses.Find(id);
            db.AspNetCourses.Remove(aspNetCourse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CourseList()
        {
            return View(db.AspNetCourses.ToList());
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
