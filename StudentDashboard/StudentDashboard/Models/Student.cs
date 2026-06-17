using System.ComponentModel.DataAnnotations;

namespace StudentDashboard.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Range(0, 100)]
        public int Progress { get; set; }

        public string Course { get; set; } = "";
    }
}
