using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string TaskName { get; set; }

        public bool IsCompleted { get; set; } = false;

        [MaxLength(20)]
        public string Priority { get; set; } = "Medium";
    }
}