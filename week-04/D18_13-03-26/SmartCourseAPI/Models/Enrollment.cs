using System.ComponentModel.DataAnnotations;

namespace SmartCourseAPI.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}