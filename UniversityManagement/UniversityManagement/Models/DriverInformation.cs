using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class DriverInformation
    {
        [Key]
        public int Id { get; set; }
        public string DriverName { get; set; }
        public string Phone { get; set; }
        public string BusNo { get; set; }
        public int RouteId { get; set; }
    }
}