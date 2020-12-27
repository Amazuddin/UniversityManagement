using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public int DepartmentId { get; set; }
        public int SemesterId { get; set; }
    }
}