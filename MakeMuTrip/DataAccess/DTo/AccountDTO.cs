namespace MakeMuTrip.DataAccess.DTo
{
    public class AccountDTO:ViewModelBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
