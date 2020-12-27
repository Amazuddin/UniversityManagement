using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Models;
using UniversityManagement.Context;

namespace UniversityManagement.Controllers
{
    public class CourseController : Controller
    {
        private UniversityContext db = new UniversityContext();

        // GET: /Course/
        public ActionResult Index()
        {
            ViewBag.Index = "active";
            return View(db.Courses.ToList());
        }

        // GET: /Course/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Course course = db.Courses.Find(id);
        //    if (course == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(course);
        //}

        // GET: /Course/Create
        public ActionResult Create()
        {
            ViewBag.Department = db.Departments.ToList();
            return View();
        }

        // POST: /Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,CourseCode,Name,Credit,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                course.CourseCode = course.CourseCode;
                course.Name = course.Name;
                course.Credit = course.Credit;
                course.DepartmentId = course.DepartmentId;
                course.SemesterId = course.SemesterId;
                db.Courses.Add(course);
                db.SaveChanges();
             
            }
            return RedirectToAction("Create", new { message = "Course information Successfully inserted" });
        }

        // GET: /Course/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Department = db.Departments.ToList();
            ViewBag.Semester = db.Semesters.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: /Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,CourseCode,Name,Credit,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: /Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: /Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
