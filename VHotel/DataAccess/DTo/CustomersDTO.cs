namespace MakeMuTrip.DataAccess.DTo
{
    public class CustomersDTO : ViewModelBase
    {
        public int AccountRefID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public IFormFile? ProfilePhotoTouplode { get; set; }
        public byte[]? ProfilePhoto { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public char Gender { get; set; }
        public int CityRefId { get; set; }
        public int StateRefId { get; set; }
        public int CountryRefId { get; set; }
        public long PinCode { get; set; }
        public long Telephone1 { get; set; }
        public string Email1 { get; set; } = null!;
    }
}
