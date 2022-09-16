using Microsoft.AspNetCore.Identity;

namespace VHotel.DataAccess.Model.Master
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
