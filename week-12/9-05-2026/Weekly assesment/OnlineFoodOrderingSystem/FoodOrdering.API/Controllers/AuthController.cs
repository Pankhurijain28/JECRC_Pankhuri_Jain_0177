using FoodOrdering.API.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FoodOrdering.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(
            UserManager<IdentityUser> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var userExists =
                await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null)
                return BadRequest("User already exists.");

            IdentityUser user = new()
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result =
                await _userManager.CreateAsync(
                    user,
                    model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(
                user,
                "Customer");

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user =
                await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return Unauthorized(
                    "Invalid email or password.");

            var isPasswordValid =
                await _userManager.CheckPasswordAsync(
                    user,
                    model.Password);

            if (!isPasswordValid)
                return Unauthorized(
                    "Invalid email or password.");

            var roles =
                await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.Name,
                    user.UserName!)
            };

            foreach (var role in roles)
            {
                authClaims.Add(
                    new Claim(
                        ClaimTypes.Role,
                        role));
            }

            var authSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        _configuration["Jwt:Key"]!));

            var token = new JwtSecurityToken(
                issuer:
                    _configuration["Jwt:Issuer"],

                audience:
                    _configuration["Jwt:Audience"],

                expires:
                    DateTime.Now.AddHours(3),

                claims:
                    authClaims,

                signingCredentials:
                    new SigningCredentials(
                        authSigningKey,
                        SecurityAlgorithms.HmacSha256)
            );

            return Ok(new
            {
                token =
                    new JwtSecurityTokenHandler()
                        .WriteToken(token),

                expiration = token.ValidTo,

                roles
            });
        }

        [HttpPost("make-admin")]
        public async Task<IActionResult> MakeAdmin(
            string email)
        {
            var user =
                await _userManager.FindByEmailAsync(email);

            if (user == null)
                return NotFound("User not found.");

            var result =
                await _userManager.AddToRoleAsync(
                    user,
                    "Admin");

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok($"{email} is now an Admin.");
        }
    }
}