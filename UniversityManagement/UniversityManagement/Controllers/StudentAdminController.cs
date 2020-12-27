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
    public class StudentAdminController : Controller
    {
        private UniversityContext db = new UniversityContext();

        // GET: /StudentAdmin/
        public ActionResult Index()
        {
            ViewBag.Index = "active";
            return View(db.Students.ToList());
        }

        // GET: /StudentAdmin/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Student student = db.Students.Find(id);
        //    if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(student);
        //}

        // GET: /StudentAdmin/Create
        public ActionResult Create()
        {
            ViewBag.Department = db.Departments.ToList();
            return View();
        }

        // POST: /StudentAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,RegistrationNo,Email,ContactNo,Address,DepartmentId,Password")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.Name = student.Name;
                student.RegistrationNo = student.RegistrationNo;
                student.Email = student.Email;
                student.DepartmentId = student.DepartmentId;
                student.ContactNo = student.ContactNo;
                student.Address = student.Address;
                student.Password = student.Password;
                db.Students.Add(student);
                db.SaveChanges();
            }

            return RedirectToAction("Create", new { message = "Student information Successfully inserted" });
        }

        // GET: /StudentAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Department = db.Departments.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /StudentAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,RegistrationNo,Email,ContactNo,Address,DepartmentId,Password")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: /StudentAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /StudentAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
