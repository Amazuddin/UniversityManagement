using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BookPdf { get; set; }
        public int DepartmentId { get; set; }
        public int SemesterId { get; set; }
    }
}