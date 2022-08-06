using MakeMyTrip.Data;

namespace MakeMyTrip.Models.Services
{
    public interface IBooksServices
    {
        Task<List<Books>> GetallAsyncbooks(string a, int page);
        Task<string> inserttodpAsync(string SubjectName, int pagenumber);
        List<Dropdown> dropdown();
        Task<List<BookDetailsDTO>> GetallAsync();
        Task<BookDetailsDTO> getbyid(int id);
        Task insertDetailsAsync();
    }
}