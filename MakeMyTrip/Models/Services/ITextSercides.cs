using MakeMyTrip.Data;

namespace MakeMyTrip.Models.Services
{
    public interface ITextSercides
    {
        Task <API_Obj> GetallAsync(string a="INR");

         List<Dropdown> dropdown();





    }
}