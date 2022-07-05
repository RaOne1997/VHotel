using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace staticclassmodel.DataAccess.Model.Master
{
    [Table("Airport", Schema = "RoomDetails")]
    [Index(nameof(AirportCode), IsUnique = true)]
    [Index(nameof(Telephone1), IsUnique = true)]
    [Index(nameof(Telephone2), IsUnique = true)]
    [Index(nameof(Email1), IsUnique = true)]
    [Index(nameof(Email2public), IsUnique = true)]
    public class Airport : DataModelBase
    {
    
        public string AirportName { get; set; } = null!;
        public string AirportCode { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string Address2 { get; set; } = null!;
        public string Address3 { get; set; } = null!;
        [Required]
        public int CityRefId { get; set; }
        [ForeignKey(nameof(CityRefId))]
        public CityMaster CityMaster { get; set; } = null!;
        public string PinCode { get; set; } = null!;
        public string Telephone1 { get; set; } = null!;
        public string Telephone2 { get; set; } = null!;
        public string Email1 { get; set; } = null!;
        public string Email2public { get; set; } = null!;
    }
}

