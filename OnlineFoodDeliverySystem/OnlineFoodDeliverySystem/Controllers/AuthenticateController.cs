using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Models.Authentication.Login;
using OnlineFoodDeliverySystem.Models.Authentication.Register;
using OnlineFoodDeliverySystem.Models.DbContext;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineFoodDeliverySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;
        public AuthenticateController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ApplicationDbContext _context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _dbContext = _context;

        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                   

            });
                 

            }
            return Unauthorized();
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {

            var customUserDetails = new CustomUserTable
            {
                UserName=registerUser.Username,
                Email=registerUser.Email

            };

            _dbContext.CustomUserDetails.Add(customUserDetails);
            await _dbContext.SaveChangesAsync();
            //Check User Exist
            var userExists = await _userManager.FindByNameAsync(registerUser.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { Status = "Error", Message = "User already exists!" });

            //add the user in the database
            IdentityUser user = new IdentityUser()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username
                
            };
           
          
          
            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, 
                        new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

                }

                // Add role to the User...
               await _userManager.AddToRoleAsync(user,role);
                return StatusCode(StatusCodes.Status200OK,
                       new Response { Status = "Success", Message = "User created successfully" });

            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       new Response { Status = "Error", Message = "This Role Doesnot Exist" });

            }
          

        }


    
    }
}
