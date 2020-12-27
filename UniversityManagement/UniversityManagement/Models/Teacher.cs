using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Degree { get; set; }
        public int DepartmentId { get; set; }
        public string Image { get; set; }

    }
}