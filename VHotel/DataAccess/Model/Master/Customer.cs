using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MakeMuTrip.DataAccess.Model.Master;

namespace staticclassmodel.DataAccess.Model.Masters
{
    public class Customer : DataModelBase
    {

        public int AccountRefID { get; set; }
        [ForeignKey(nameof(AccountRefID))]
        public Account account { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public byte[]? ProfilePhoto { get; set; }
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }

        public char Gender { get; set; }  
        public int CityRefId { get; set; }
        [ForeignKey(nameof(CityRefId))]

        public CityMaster CityMaster { get; set; }

        public int StateRefId { get; set; }
        [ForeignKey(nameof(StateRefId))]

        public State state { get; set; }

        public int CountryRefId { get; set; }
        [ForeignKey(nameof(CountryRefId))]

        public Country? country { get; set; }
        public long PinCode { get; set; }
        public long Telephone1 { get; set; }

        public string Email1 { get; set; } = null!;
    }
}
