using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string TransportUser { get; set; }
    }
}