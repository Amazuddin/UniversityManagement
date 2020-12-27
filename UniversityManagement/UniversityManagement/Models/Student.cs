using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegistrationNo { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string Password { get; set; }
    }
}