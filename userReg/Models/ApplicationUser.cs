using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema; // [Column]
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace userReg.Models{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName ="nvarchar(150)")]
        public string FullName { get; set; }
    }
}