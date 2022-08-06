namespace MakeMyTrip.Data.DTO
{
    public class Pagination
    {
        public string total { get; set; }
        public string page { get; set; }
        public ICollection<BooksDTO> books { get; set; }
    }


}