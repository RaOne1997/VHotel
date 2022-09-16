using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VHotel.DataAccess.Model.security;

namespace VHotel.Services
{
    public class AuthTokenService : IAuthTokenService
    {

        private readonly JwtSecuritySettings _jwtSecuritySettings;

        public AuthTokenService(IOptions<JwtSecuritySettings> jwtSecuritySettingOptions)
        {
            _jwtSecuritySettings = jwtSecuritySettingOptions.Value;
        }

        public AuthResponse GetAuthToken(string username, string password)
        {
            //if (username =="" || password == "")
            //    throw new AuthFailedException("Invalid UserName and/or Password");

            // Get token and expiryDatetime
            var expiryDateTime = DateTime.Now.AddSeconds(1);
            var tokenKey = Encoding.ASCII.GetBytes(_jwtSecuritySettings.SecurityKey);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new List<Claim>
            {
                new("userName", username),
                new("expiresIn", expiryDateTime.ToString()),
            }),
                Expires = expiryDateTime,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthResponse { Token = token, ExpiryDateTime = expiryDateTime };
            //return new AuthResponse {Token = "asdghfsgsdlhsgshgs", ExpiryDateTime = DateTime.Now.AddMinutes(5)};
        }
    }
}
