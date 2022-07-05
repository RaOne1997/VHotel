

namespace VHotel.DataAccess.DTo
{
    public class StateDTO: ViewModelBase
    {

        public string StateID { get; set; } = null!;
        public string StateName { get; set; } = null!;
        public int CountryrefID { get; set; }
    }
}
