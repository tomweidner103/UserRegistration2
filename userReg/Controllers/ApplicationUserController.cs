using System.Net.NetworkInformation;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using userReg.Models;
using System.Text;

namespace userReg.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _appSettings;

        // this is the constructor
        public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager; // accessing injected instances from services.AddDefaultIdentity
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
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
                FullName = model.FullName,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                EmergencyName = model.EmergencyName,
                EmergencyNumber = model.EmergencyNumber,
                EventCode = model.EventCode
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

        [HttpPost]
        [Route("Login")]
        // POST /ApplicationUser/Login

        public async Task<IActionResult> Login(LoginModel model) 
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor 
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new {token});
            } else {
                return BadRequest(new { message = "Email or password is incorrect"});
            }
        }
    }
}