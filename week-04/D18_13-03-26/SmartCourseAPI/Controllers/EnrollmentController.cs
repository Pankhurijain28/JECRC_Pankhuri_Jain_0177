using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SmartCourseAPI.Data;
using SmartCourseAPI.Models;

namespace SmartCourseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }

        // FR6 - Enroll in Course
        [Authorize(Roles = "Student")]
        [HttpPost("enroll")]
        public IActionResult Enroll(int courseId, int studentId)
        {
            var course = _context.Courses.Find(courseId);

            if (course == null)
                return NotFound("Course not found");

            if (course.SeatsAvailable <= 0)
                return BadRequest("No seats available");

            var enrollment = new Enrollment
            {
                CourseId = courseId,
                StudentId = studentId,
                EnrollmentDate = DateTime.Now
            };

            course.SeatsAvailable--;

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            return Ok("Enrollment successful");
        }

        // FR7 - Drop Course
        [Authorize(Roles = "Student")]
        [HttpDelete("drop")]
        public IActionResult DropCourse(int courseId, int studentId)
        {
            var enrollment = _context.Enrollments
                .FirstOrDefault(e => e.CourseId == courseId && e.StudentId == studentId);

            if (enrollment == null)
                return NotFound("Enrollment not found");

            var course = _context.Courses.Find(courseId);
            if (course != null)
                course.SeatsAvailable++;

            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();

            return Ok("Course dropped successfully");
        }

        // View student enrolled courses
        [Authorize(Roles = "Student")]
        [HttpGet("student/{studentId}")]
        public IActionResult GetStudentCourses(int studentId)
        {
            var enrollments = _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .ToList();

            return Ok(enrollments);
        }

        // FR8 - Admin view all enrollments
        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public IActionResult GetAllEnrollments()
        {
            var enrollments = _context.Enrollments.ToList();

            return Ok(enrollments);
        }
    }
}