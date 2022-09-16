namespace MakeMuTrip.DataAccess.DTo
{
    public class CountryDTO:ViewModelBase
    {
        public string CountryID { get; set; } = null!;
        public string CountryCode { get; set; } = null!;
        public string CountryName { get; set; } = null!;
    }
}
