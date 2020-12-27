using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class ResultView
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public double CourseCredit { get; set; }
        public string Grade { get; set; }
        public float GradePoint { get; set; }
        public string Semester { get; set; }
    }
}