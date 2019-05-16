using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema; // [Column]
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace userReg.Models{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyNumber { get; set; }
        public string EventCode { get; set; }
    }
}