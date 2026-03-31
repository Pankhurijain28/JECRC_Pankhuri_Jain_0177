using Microsoft.AspNetCore.Mvc;
using SmartCourseAPI.Data;
using SmartCourseAPI.DTOs;
using SmartCourseAPI.Models;
using SmartCourseAPI.Services;

namespace SmartCourseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwt;

        public AuthController(AppDbContext context, JwtService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        // Register Admin
        [HttpPost("register-admin")]
        public IActionResult RegisterAdmin(RegisterDTO dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "Admin"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("Admin registered successfully");
        }

        // Register Student
        [HttpPost("register-student")]
        public IActionResult RegisterStudent(RegisterDTO dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "Student"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("Student registered successfully");
        }

        // Login
        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == dto.Email);

            if (user == null)
                return Unauthorized("Invalid email");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid password");

            var token = _jwt.GenerateToken(user);

            return Ok(new
            {
                token,
                role = user.Role,
                name = user.Name
            });
        }
    }
}