namespace MakeMuTrip.DataAccess.DTo
{
    public class AirportDTO : ViewModelBase
    {
        public string AirportName { get; set; } = null!;
        public string AirportCode { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; } = null!;
        public string? Address3 { get; set; } = null!;
        public byte[]? AirportImage { get; set; } = null!;
        public IFormFile? AirportImageUplode { get; set; } = null!;
        public int CityRefId { get; set; }
        public string CityName { get; set; }
        public string PinCode { get; set; } = null!;
        public string Telephone1 { get; set; } = null!;
        public string? Telephone2 { get; set; } = null!;
        public string Email1 { get; set; } = null!;
        public string Email2public { get; set; } = null!;
        public bool Isactive { get; set; } = false;
    }
}
