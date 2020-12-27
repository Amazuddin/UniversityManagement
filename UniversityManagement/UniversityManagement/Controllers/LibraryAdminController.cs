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
    public class LibraryAdminController : Controller
    {
        private UniversityContext db = new UniversityContext();

        // GET: /LibraryAdmin/
        public ActionResult Index()
        {
            ViewBag.Index = "active";
            return View(db.Librarys.ToList());
        }

        // GET: /LibraryAdmin/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Library library = db.Librarys.Find(id);
        //    if (library == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(library);
        //}

        // GET: /LibraryAdmin/Create
        public ActionResult Create()
        {
            ViewBag.depart = db.Departments.ToList();
            return View();
        }

        // POST: /LibraryAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BookPdf,DepartmentId,SemesterId")] Library library, HttpPostedFileBase BookPdf)
        {
            
                if (BookPdf != null && BookPdf.ContentLength > 0)
                {

                    try
                    {
                        string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(BookPdf.FileName);
                        string fName = "Book/";
                        string uploadUrl = Server.MapPath("~/Book");
                        BookPdf.SaveAs(Path.Combine(uploadUrl, fileName));
                        string Name = string.Concat(fName, fileName);
                        library.BookPdf = Name;
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }
                library.DepartmentId = library.DepartmentId;
                library.SemesterId = library.SemesterId;
                library.Name = library.Name;
                library.BookPdf = library.BookPdf;
                db.Librarys.Add(library);
                db.SaveChanges();
                //return RedirectToAction("Index");
            

            return RedirectToAction("Create", new { message = "Book Successfully inserted" });
        }

        // GET: /LibraryAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = db.Librarys.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // POST: /LibraryAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,BookPdf,DepartmentId,SemesterId")] Library library)
        {
            if (ModelState.IsValid)
            {
                db.Entry(library).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(library);
        }

        // GET: /LibraryAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library library = db.Librarys.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // POST: /LibraryAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Library library = db.Librarys.Find(id);
            db.Librarys.Remove(library);
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
