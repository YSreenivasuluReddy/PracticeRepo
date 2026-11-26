namespace ProjectApi.Models
{
    public class RefreshToken
    {
        public int RefreshTokenId { get; set; }
        public int UserId { get; set; }
        // Store only a SHA-256 hash of the random refresh token, never the raw token.
        public string TokenHash { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? RevokedDate { get; set; }
        public bool IsRevoked => RevokedDate.HasValue;
    }
}
