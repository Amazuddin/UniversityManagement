using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Context;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    public class UniversityController : Controller
    {
        //
        // GET: /University/
        public ActionResult Index()
        {
            ViewBag.Index = "active";
            return View();
        }

        public ActionResult RouteInformation()
        {
            ViewBag.RouteInformation = "active";
            List<User> transportusers;
            List<Routes> routes;
            using (var db = new UniversityContext())
            {

                transportusers = db.TransportUsers.ToList();
                routes = db.Routes.ToList();
            }

            ViewBag.Category = transportusers;
            ViewBag.routes = routes;
            return View();
        }

        public JsonResult GetAllRouteInfoById(int id, int routeid)
        {

            List<RouteInformations> routs = new List<RouteInformations>();
            using (var db = new UniversityContext())
            {
                var a = db.RouteInformations.Where(s => s.UserId == id && s.RouteId == routeid);
                foreach (var k in a)
                {
                    RouteInformations routeInformations = new RouteInformations();
                    routeInformations.VehicleNo = k.VehicleNo;
                    routeInformations.RouteId = k.RouteId;
                    routeInformations.UserId = k.UserId;
                    routeInformations.StartTime = k.StartTime;
                    routeInformations.DepartureTime = k.DepartureTime;
                    routeInformations.DriverName = k.DriverName;
                    routeInformations.Phone = k.Phone;
                    routs.Add(routeInformations);
                }
            }
            return Json(routs);
        }

        //************************************Library*****************************************//
        public ActionResult LibraryBook()
        {
            ViewBag.LibraryBook = "active";
            List<Department> departments;
            List<Library> libraries;
            using (var db = new UniversityContext())
            {

                departments = db.Departments.ToList();
                libraries = db.Librarys.ToList();

            }

            ViewBag.dept = departments;
            ViewBag.lib = libraries;
            return View();
        }

        public JsonResult GetAllPdfbyId(int id, int semid)
        {

            List<Library> libs = new List<Library>();
            using (var db = new UniversityContext())
            {
                var a = db.Librarys.Where(s => s.DepartmentId == id && s.SemesterId == semid);
                foreach (var k in a)
                {
                    Library library = new Library();
                    library.Name = k.Name;
                    library.BookPdf = k.BookPdf;

                    libs.Add(library);
                }
            }
            return Json(libs);
        }

        //***********************************Teacher**************************************//
        public ActionResult Teacher()
        {
            ViewBag.CSEDepartment = "active";
            List<Department> departments;
            List<Teacher> Dlist = new List<Teacher>();
            using (var db = new UniversityContext())
            {
                departments = db.Departments.ToList();
                Dlist = db.Teachers.ToList();
            }

            ViewBag.dept = departments;
            ViewBag.Teacher = Dlist;
            return View();
        }

        public JsonResult GetAllTeacherById(int id)
        {

            List<Teacher> Dlist = new List<Teacher>();
            using (var ctx = new UniversityContext())
            {
                var k =
                    ctx.Teachers.Where(c => c.DepartmentId == id)
                        .Select(c => new {c.Id, c.Name, c.Designation, c.Image, c.Degree, c.Email})
                        .ToList();
                foreach (var dc in k)
                {
                    Teacher d = new Teacher();
                    d.Id = dc.Id;
                    d.Name = dc.Name;
                    d.Image = dc.Image;
                    d.Designation = dc.Designation;
                    d.Degree = dc.Degree;
                    d.Email = dc.Email;
                    Dlist.Add(d);
                }
            }

            return Json(Dlist);

        }

        //*************************************Course**********************************//
        public ActionResult Course()
        {
            ViewBag.Course = "active";
            List<Department> department;
            using (var db = new UniversityContext())
            {
                department = db.Departments.ToList();
            }
            ViewBag.Department = department;
            return View();
        }

        public JsonResult GetAllCourseInfoById(int id, int semid)
        {

            List<Course> courses = new List<Course>();
            using (var db = new UniversityContext())
            {
                var a = db.Courses.Where(s => s.DepartmentId == id && s.SemesterId == semid);
                foreach (var k in a)
                {
                    Course course = new Course();
                    course.Name = k.Name;
                    course.CourseCode = k.CourseCode;
                    course.Credit = k.Credit;
                    courses.Add(course);
                }
            }
            return Json(courses);
        }

        //***********************************Result******************************//
        public ActionResult Marks()
        {
            ViewBag.Marks = "active";
            List<Department> department;
            List<Semester> semesters;
            List<Grade> grades;
            List<Student> students;
            using (var db = new UniversityContext())
            {
                department = db.Departments.ToList();
                semesters = db.Semesters.ToList();
                grades = db.Grades.ToList();
                students = db.Students.ToList();
            }
            ViewBag.Department = department;
            ViewBag.Semester = semesters;
            ViewBag.Grade = grades;
            ViewBag.Student = students;
            return View();
        }

        public JsonResult GetCoursebyStudentsem(int id)
        {

            List<Course> courses = new List<Course>();
            using (var db = new UniversityContext())
            {
                var a = db.Courses.Where(s => s.SemesterId == id);
                foreach (var k in a)
                {
                    Course course = new Course();
                    course.Id = k.Id;
                    course.Name = k.Name;
                    courses.Add(course);
                }
            }
            return Json(courses);
        }

        [HttpPost]
        public ActionResult Marks(Result result)
        {
            ViewBag.Marks = "active";
            List<Department> department;
            List<Semester> semesters;
            List<Grade> grades;
            List<Student> students;
            using (var db = new UniversityContext())
            {
                department = db.Departments.ToList();
                semesters = db.Semesters.ToList();
                grades = db.Grades.ToList();
                students = db.Students.ToList();
                db.Results.Add(result);
                db.SaveChanges();
            }
            ViewBag.Department = department;
            ViewBag.Semester = semesters;
            ViewBag.Grade = grades;
            ViewBag.Student = students;
            ViewBag.Yes = '1';
            return View();
        }

        public ActionResult ViewResult()
        {
            ViewBag.ViewResult = "active";

            List<Student> students;
            using (var db = new UniversityContext())
            {

                students = db.Students.ToList();
            }

            ViewBag.Student = students;
            return View();
        }

        public JsonResult GetResultbyStudentreg(int id)
        {
            List<ResultView> pt = new List<ResultView>();

            using (var db = new UniversityContext())
            {
                var q =
                    (from a in db.Results
                        join p in db.Courses on a.CourseId equals p.Id
                        join c in db.Grades on a.GradeId equals c.Id
                        where a.StudentId == id
                        select new
                        {

                            aName = p.Name,
                            aCourseCode = p.CourseCode,
                            acredit = p.Credit,
                            aPoint = c.Point,
                            agradename = c.Name
                        });
                foreach (var j in q)
                {
                    ResultView res = new ResultView();
                    res.CourseName = j.aName;
                    res.CourseCode = j.aCourseCode;
                    res.CourseCredit = j.acredit;
                    res.Grade = j.agradename;
                    res.GradePoint = j.aPoint;
                    pt.Add(res);

                }

            }
            return Json(pt);
        }

        public ActionResult MakePdf()
        {
            return View();
        }

        public ActionResult Profile()
        {
            ViewBag.Profile = "active";
            int studentid = Convert.ToInt32(Session["StudentId"]);
            List<ResultView> pt = new List<ResultView>();
            Student stu = new Student();
            using (var db = new UniversityContext())
            {
                var q =
                    (from a in db.Results
                        join p in db.Courses on a.CourseId equals p.Id
                        join c in db.Grades on a.GradeId equals c.Id
                        join s in db.Semesters on a.SemesterId equals s.Id
                        where a.StudentId == studentid
                        select new
                        {
                            aName = p.Name,
                            aCourseCode = p.CourseCode,
                            acredit = p.Credit,
                            aPoint = c.Point,
                            agradename = c.Name,
                            asem=s.Name
                        });
                foreach (var j in q)
                {
                    ResultView res = new ResultView();
                    res.CourseName = j.aName;
                    res.CourseCode = j.aCourseCode;
                    res.CourseCredit = j.acredit;
                    res.Grade = j.agradename;
                    res.GradePoint = j.aPoint;
                    res.Semester = j.asem;
                    pt.Add(res);

                }
                var am = db.Students.Where(s => s.Id == studentid);
                foreach (var k in am)
                {
                    
                    stu.Name = k.Name;
                    stu.Email = k.Email;
                    stu.Address = k.Address;
                    stu.RegistrationNo = k.RegistrationNo;
                    stu.ContactNo = k.ContactNo;
                    
                }
                ViewBag.Allinfo = stu;
            }
            ViewBag.All = pt;
           
            return View();

        }
    }
}