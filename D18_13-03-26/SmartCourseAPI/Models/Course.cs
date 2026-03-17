using System.ComponentModel.DataAnnotations;

namespace SmartCourseAPI.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public string CourseName { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public int Credits { get; set; }

        public int SeatsAvailable { get; set; }
    }
}