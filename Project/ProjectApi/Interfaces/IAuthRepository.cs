using ProjectApi.Models;

namespace ProjectApi.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetUserByEmailAsync(string email);

        Task<User?> GetUserByIdAsync(int userId);

        Task AddUserAsync(User user);
    }
}
