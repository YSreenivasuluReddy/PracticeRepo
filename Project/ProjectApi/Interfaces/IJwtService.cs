using ProjectApi.Models;

namespace ProjectApi.Interfaces
{
    public interface IJwtService
    {
        (string Token, DateTime ExpiresAt) GenerateAccessToken(User user);
        string GenerateRefreshToken();
        string HashRefreshToken(string token);
    }
}
