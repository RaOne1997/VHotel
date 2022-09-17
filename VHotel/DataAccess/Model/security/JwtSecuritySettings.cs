using VHotel.DataAccess.Model.Master;

namespace VHotel.DataAccess.Model.security
{
    public class JwtSecuritySettings
    {
        public string SecurityKey { get; set; } = null!;
        public int TokenValiditySeconds { get; set; }
    }
    public class AuthResponse
    {
        public string Token { get; set; }
        public DateTime ExpiryDateTime { get; set; }

        public User users { get; set; }

        public string Role { get; set; }
    }
    public class TokenCredential
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
    public class AuthFailedException : Exception
    {
        public AuthFailedException(string message) : base(message)
        {
        }
    }
}
