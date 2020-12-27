using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class RouteInformations
    {
        [Key]
        public int Id { get; set; }
        public string VehicleNo { get; set; }
        public int RouteId { get; set; }
        public int UserId { get; set; }
        public string StartTime { get; set; }
        public string DepartureTime { get; set; }
        public string DriverName { get; set; }
        public string Phone { get; set; }
    }
}