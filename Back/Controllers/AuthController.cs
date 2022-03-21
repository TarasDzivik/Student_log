//using Back.Data.Models.Entities;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.Extensions.Configuration;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using System.Text;
//using System.Security.Claims;
//using System.IdentityModel.Tokens.Jwt;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Linq;

//namespace Back.Controllers
//{
//    [Authorize]
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthController : ControllerBase
//    {
//        private readonly UserManager<User> userManager;
//        private readonly RoleManager<IdentityRole> roleManager;
//        private readonly IConfiguration configuration;
//        private readonly ILogger<AuthController> logger;

//        public AuthController(UserManager<User> userManager,
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
//        public async Task<IActionResult> Login([FromBody] AuthRequest model)
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
//                    token = new JwtSecurityTokenHandler().WriteToken(token),
//                    expiration = token.ValidTo
//                });
//            }
//            return Unauthorized();
//        }

//        [HttpPost]
//        [Route("registration")]
//        public async Task<IActionResult> Registration([FromBody] RegistrationRequest model)
//        {
//            var userExist = await userManager.FindByEmailAsync(model);
//            if (userExist != null)
//            {
//                return StatusCode(409);
//            }

//            User user = new()
//            {
//                Name = model.Name,
//                LastName = model.LastName,
//                Email = model.Email,
//                Age = Convert.ToInt32(model.Age),
//                ImagePath = model.ImagePath,
//                SecurityStamp = Guid.NewGuid().ToString()
//            };
//            var result = await userManager.CreateAsync(user, model.Password);
//            if (!result.Succeeded)
//            {
//                return StatusCode(500); // повiдомлення згенерити на клієнті
//            }
//            return Ok();

//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public async Task<IActionResult> ConfirmEmail(string userId, string code)
//        {
//            if (userId == null || code == null)
//            {
//                return NotFound();
//            }
//            var user = await userManager.FindByIdAsync(userId);
//            if (user == null)
//            {
//                return BadRequest();
//            }
//            var result = await userManager.ConfirmEmailAsync(user, code);
//            if (result.Succeeded)
//            {
//                return Ok();
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }

//        [HttpPost]
//        [Route("admin/registration")]
//        public async Task<IActionResult> AdminRegistration([FromBody] RegisterRequest model)
//        {
//            var users = await userManager.FindByEmailAsync(model); //знайти перший елемент за доп linq
//            if (users != null)
//            {
//                return StatusCode(409);
//            }

//            User user = new()
//            {
//                Name = model.Name,
//                LastName = model.LastName,
//                Email = model.Email,
//                Age = Convert.ToInt32(model.Age),
//                SecurityStamp = Guid.NewGuid().ToString()
//            };

//            var result = await userManager.CreateAsync(user, model.Password);
//            if (!result.Succeeded)
//            {
//                return StatusCode(500); // повiдомлення згенерити на клієнті
//            }
//            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
//            {
//                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
//            }
//            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
//            {
//                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
//            }
//            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
//            {
//                await userManager.AddToRoleAsync(user, UserRoles.Admin);
//            }
//            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
//            {
//                await userManager.AddToRoleAsync(user, UserRoles.User);
//            }
//            return Ok();
//        }

//        private JwtSecurityToken GenerateToken(List<Claim> authClaims)
//        {
//            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
//            const int validForThreeHours = 3;
//            var token = new JwtSecurityToken
//                (
//                    issuer: configuration["JWT:ValidIssuer"],
//                    audience: configuration["JWT:ValidAudience"],
//                    expires: DateTime.UtcNow.AddHours(validForThreeHours),
//                    claims: authClaims,
//                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
//                );
//            return token;
//        }

//    }
//}