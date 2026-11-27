using ProjectApi.Models;

namespace ProjectApi.Data
{
    public class InMemoryStore
    {
        // Used for thread-safe access to the lists.
        public object SyncRoot { get; } = new();

        public List<User> Users { get; } = new()
    {
        new User
        {
            UserId = 1,
            FullName = "Rahul Sharma",
            Email = "rahul@gmail.com",
            Mobile = "9876543210",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
            Role = "Admin",
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        },

        new User
        {
            UserId = 2,
            FullName = "Suresh Kumar",
            Email = "suresh@gmail.com",
            Mobile = "9876543211",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("User@123"),
            Role = "User",
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        }
    };

        public List<Student> Students { get; } = new()
    {
        new Student
        {
            StudentId = 1,
            FirstName = "Arun",
            LastName = "Kumar",
            Age = 22,
            Course = "Computer Science",
            Email = "arun@gmail.com"
        },

        new Student
        {
            StudentId = 2,
            FirstName = "Priya",
            LastName = "Sharma",
            Age = 21,
            Course = "Mechanical Engineering",
            Email = "priya@gmail.com"
        },

        new Student
        {
            StudentId = 3,
            FirstName = "Kiran",
            LastName = "Reddy",
            Age = 23,
            Course = "Electronics",
            Email = "kiran@gmail.com"
        }
    };

        public List<RefreshToken> RefreshTokens { get; } = new();
    }
}
