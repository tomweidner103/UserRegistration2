using System;
using System.Collections.Generic;
using System.Linq; // Route
using System.Threading.Tasks; // Route
using Microsoft.AspNetCore.Http; // HttpGet
using Microsoft.AspNetCore.Mvc; // Controller Base
using Microsoft.AspNetCore.Authorization; //Authorize
using Microsoft.AspNetCore.Identity; // UserManager
using userReg.Models; // ApplicationUser

namespace userReg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        // GET : /api/UserProfile
        public async Task<Object> GetUserProfile() 
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }
    }
}