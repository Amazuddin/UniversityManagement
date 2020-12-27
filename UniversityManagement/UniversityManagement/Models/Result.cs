using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int SemesterId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int GradeId { get; set; }
        public string Date { get; set; }

    }
}