using StudentDashboard.Models;

namespace StudentDashboard.Serices
{
    public class StudentStateService
    {
        public List<Student> Students { get; set; } = new()
    {
        new()
        {
            Id = 1,
            Name = "John",
            Email = "john@test.com",
            Course = "Blazor",
            Progress = 80
        },
        new()
        {
            Id = 2,
            Name = "Sarah",
            Email = "sarah@test.com",
            Course = "ASP.NET Core",
            Progress = 60
        }
    };
    }
}
