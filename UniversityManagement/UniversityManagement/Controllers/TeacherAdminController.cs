using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Models;
using UniversityManagement.Context;

namespace UniversityManagement.Controllers
{
    public class TeacherAdminController : Controller
    {
        private UniversityContext db = new UniversityContext();

        // GET: /TeacherAdmin/
        public ActionResult Index()
        {
            ViewBag.Index = "active";
            return View(db.Teachers.ToList());
        }

        // GET: /TeacherAdmin/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Teacher teacher = db.Teachers.Find(id);
        //    if (teacher == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(teacher);
        //}

        // GET: /TeacherAdmin/Create
        public ActionResult Create()
        {
            ViewBag.Department = db.Departments.ToList();
            return View();
        }

        // POST: /TeacherAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Designation,Degree,DepartmentId,Image")] Teacher teacher, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null && Image.ContentLength > 0)
                {

                    try
                    {
                        string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(Image.FileName);
                        string uploadUrl = Server.MapPath("~/picture");
                        Image.SaveAs(Path.Combine(uploadUrl, fileName));
                        teacher.Image = "picture/" + fileName;
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }
               
                teacher.Name = teacher.Name;
                teacher.Email = teacher.Email;
                teacher.Degree = teacher.Degree;
                teacher.Designation = teacher.Designation;
                db.Teachers.Add(teacher);
                db.SaveChanges();
               
            }

            return RedirectToAction("Create", new { message = "Teacher added Successfully" });
        }

        // GET: /TeacherAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Department = db.Departments.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: /TeacherAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Designation,Degree,DepartmentId,Image")] Teacher teacher, HttpPostedFileBase Image, string pastImage)
        {
            if (ModelState.IsValid)
            {
                if (Image != null && Image.ContentLength > 0)
                {

                    try
                    {
                        string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(Image.FileName);
                        string uploadUrl = Server.MapPath("~/picture");
                        Image.SaveAs(Path.Combine(uploadUrl, fileName));
                        teacher.Image = "picture/" + fileName;
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }
                else
                {
                    teacher.Image = pastImage;
                }
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        // GET: /TeacherAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: /TeacherAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
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
