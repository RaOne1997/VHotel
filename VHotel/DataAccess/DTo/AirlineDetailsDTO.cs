namespace VHotel.DataAccess.DTo
{
    public class AirlineDetailsDTO :ViewModelBase
    {
        public string AirlineName { get; set; } = null!;
        public string ShortName { get; set; } = null!;

        public IFormFile? AirlineLogotoUplode { get; set; }
        public byte[]? AirlineLogo { get; set; }
       
        public long HelplineNumber { get; set; }
      
        public long? Telephone2 { get; set; }
      
        public string Email1 { get; set; } = null!;

        public string? Email2 { get; set; } = null!;
    }
}
