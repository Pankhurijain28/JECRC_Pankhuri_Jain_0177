using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SmartCourseAPI.Data;
using SmartCourseAPI.Models;

namespace SmartCourseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        // FR1 - View all courses
        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = _context.Courses.ToList();
            return Ok(courses);
        }

        // Get single course
        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        // FR3 - Add course (Admin only)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();

            return Ok(course);
        }

        // FR4 - Update course
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, Course updatedCourse)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
                return NotFound();

            course.CourseName = updatedCourse.CourseName;
            course.Department = updatedCourse.Department;
            course.Credits = updatedCourse.Credits;
            course.SeatsAvailable = updatedCourse.SeatsAvailable;

            _context.SaveChanges();

            return Ok(course);
        }

        // FR5 - Delete course
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
                return NotFound();

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return Ok("Course deleted");
        }
    }
}