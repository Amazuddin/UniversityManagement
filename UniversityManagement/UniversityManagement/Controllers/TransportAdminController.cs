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
    public class TransportAdminController : Controller
    {
        private UniversityContext db = new UniversityContext();

        // GET: /TransportAdmin/
        public ActionResult Index()
        {
            ViewBag.Index = "active";
            return View(db.RouteInformations.ToList());
        }

        // GET: /TransportAdmin/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RouteInformations routeinformations = db.RouteInformations.Find(id);
        //    if (routeinformations == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(routeinformations);
        //}

        // GET: /TransportAdmin/Create
        public ActionResult Create()
        {
            ViewBag.Route = db.Routes.ToList();
            ViewBag.Users = db.TransportUsers.ToList();
            return View();
        }

        // POST: /TransportAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,VehicleNo,RouteId,UserId,StartTime,DepartureTime,DriverName,Phone")] RouteInformations routeinformations)
        {
            if (ModelState.IsValid)
            {
                routeinformations.VehicleNo = routeinformations.VehicleNo;
                routeinformations.RouteId = routeinformations.RouteId;
                routeinformations.UserId = routeinformations.UserId;
                routeinformations.StartTime = routeinformations.StartTime;
                routeinformations.DepartureTime = routeinformations.DepartureTime;
                routeinformations.DriverName = routeinformations.DriverName;
                routeinformations.Phone = routeinformations.Phone;
                db.RouteInformations.Add(routeinformations);
                db.SaveChanges();
               
            }
            return RedirectToAction("Create", new { message = "Route information Successfully inserted" });
           
        }

        // GET: /TransportAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Route = db.Routes.ToList();
            ViewBag.Users = db.TransportUsers.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteInformations routeinformations = db.RouteInformations.Find(id);
            if (routeinformations == null)
            {
                return HttpNotFound();
            }
            return View(routeinformations);
        }

        // POST: /TransportAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,VehicleNo,RouteId,UserId,StartTime,DepartureTime,DriverName,Phone")] RouteInformations routeinformations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routeinformations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(routeinformations);
        }

        // GET: /TransportAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteInformations routeinformations = db.RouteInformations.Find(id);
            if (routeinformations == null)
            {
                return HttpNotFound();
            }
            return View(routeinformations);
        }

        // POST: /TransportAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RouteInformations routeinformations = db.RouteInformations.Find(id);
            db.RouteInformations.Remove(routeinformations);
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
