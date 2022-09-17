using MakeMuTrip.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VHotel.DataAccess.Model.Master;
using VHotel.DataAccess.Model.security;

namespace VHotel.Services
{
    public class AuthTokenService : IAuthTokenService
    {

        private readonly JwtSecuritySettings _jwtSecuritySettings;
        private readonly UserManager<User> _userManager;
        private readonly VhotelsSQLContex _vhotelsSQLContex;
        private readonly SignInManager<User> _signInManager;


        public AuthTokenService(IOptions<JwtSecuritySettings> jwtSecuritySettingOptions
              ,SignInManager<User> signInManager
            , UserManager<User> userManager,

VhotelsSQLContex vhotelsSQLContex
            )
        {
            _jwtSecuritySettings = jwtSecuritySettingOptions.Value;
            _userManager = userManager;
            _signInManager= signInManager;
         
           _vhotelsSQLContex = vhotelsSQLContex;
        }

        public async Task<AuthResponse> GetAuthTokenAsync(LoginViewModel model)
            {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (!result.Succeeded)  
               throw new AuthFailedException("Invalid UserName and/or Password");

            // Get token and expiryDatetime
            var expiryDateTime = DateTime.Now.AddSeconds(1);
            var tokenKey = Encoding.ASCII.GetBytes(_jwtSecuritySettings.SecurityKey);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new List<Claim>
            {
                new("userName", model.Email),
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
            var user = await _userManager.FindByEmailAsync(model.Email);
            var role = await (from e in _vhotelsSQLContex.Roles
                     join d in _vhotelsSQLContex.UserRoles on e.Id equals d.RoleId
                     where d.UserId == user.Id
                     select e.Name).SingleOrDefaultAsync();
            


            return new AuthResponse { Token = token, ExpiryDateTime = expiryDateTime,users=user,Role= role};
            //return new AuthResponse {Token = "asdghfsgsdlhsgshgs", ExpiryDateTime = DateTime.Now.AddMinutes(5)};
        }
    }
}
