using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityManagement.Models;

namespace UniversityManagement.Context
{
    public class UniversityContext : DbContext
    {
        public DbSet<User> TransportUsers { get; set; }
        public DbSet<Routes> Routes{ get; set; }
        public DbSet<DriverInformation> Driver { get; set; }
        public DbSet<RouteInformations> RouteInformations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Library> Librarys { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}