//using Back.Data.Models.Entities;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
//using Microsoft.IdentityModel.JsonWebTokens;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Back.Controllers
//{
//    [Authorize]
//    [ApiController]
//    [Route("api/login")]
//    public class LoginController : ControllerBase
//    {
//        private readonly UserManager<User> userManager;
//        private readonly RoleManager<IdentityRole> roleManager;
//        private readonly IConfiguration configuration;
//        private readonly ILogger<AuthController> logger;

//        public LoginController(UserManager<User> userManager,
//            RoleManager<IdentityRole> roleManager, IConfiguration configuration,
//            ILogger<AuthController> logger)
//        {
//            this.userManager = userManager;
//            this.roleManager = roleManager;
//            this.configuration = configuration;
//            this.logger = logger;
//        }

//        [HttpPost]
//        [Route("login")]
//        public async Task<IActionResult> Login([FromBody] LoginRequest model)
//        {
//            var user = await userManager.FindByEmailAsync(FindFirst); //знайти перший елемент за доп linq
//            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
//            {
//                var userRole = await userManager.GetRolesAsync(user);
//                var authClaims = new List<Claim>
//                {
//                    new Claim(ClaimTypes.Name, user.Email),
//                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//                };

//                foreach (var roles in userRoles)
//                {
//                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
//                }
//                var token = GenerateToken(authClaims);
//                return Ok(new
//                {
//                    token = new JsonWebTokenHandler().CreateToken(token),
//                    expiration = token.ValidTo
//                });
//            }
//            return Unauthorized();
//        }
//    }
//}