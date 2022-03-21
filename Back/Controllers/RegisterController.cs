//using Back.Data.Models.Entities;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Back.Controllers
//{
//    [Authorize]
//    [ApiController]
//    [Route("api/[controller]")]
//    public class RegisterController : ControllerBase
//    {
//        private readonly UserManager<User> userManager;
//        private readonly RoleManager<IdentityRole> roleManager;
//        private readonly IConfiguration configuration;
//        private readonly ILogger<AuthController> logger;

//        public RegisterController(UserManager<User> userManager,
//            RoleManager<IdentityRole> roleManager, IConfiguration configuration,
//            ILogger<AuthController> logger)
//        {
//            this.userManager = userManager;
//            this.roleManager = roleManager;
//            this.configuration = configuration;
//            this.logger = logger;
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
//                SecurityStamp = Guid.NewGuid().ToString()
//            };
//            var result = await userManager.CreateAsync(user, model.Password);
//            if (!result.Succeeded)
//            {
//                return StatusCode(500); // повiдомлення згенерити на клієнті
//            }
//            return Ok();

//        }
//    }
//}
