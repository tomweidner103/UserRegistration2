using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using userReg.Models;

namespace userReg.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        // this is the constructor
        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager; // accessing injected instances from services.AddDefaultIdentity
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        //Post : /api/ApplicationUser/Register

        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            var applicationUser = new ApplicationUser() 
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}