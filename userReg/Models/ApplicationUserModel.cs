using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userReg.Models{
    public class ApplicationUserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyNumber { get; set; }
        public string EventCode { get; set; }
    }
}