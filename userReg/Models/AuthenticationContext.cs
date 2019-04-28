using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // IdentityDbContext
using Microsoft.EntityFrameworkCore;

namespace userReg.Models
{
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}