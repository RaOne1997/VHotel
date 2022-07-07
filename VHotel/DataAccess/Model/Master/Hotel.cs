using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace staticclassmodel.DataAccess.Model.Master
{
    [Table("Hotel", Schema = "Hotels")]
    public class Hotel: DataModelBase
    {
     
        public string Name { get; set; } = null!;
        public int HotelId { get; set; }
        public byte[]? HotelImage { get; set; }
        public int HotelRating { get; set; }
        public DateTime checkout { get; set; }
        public DateTime checkin { get; set; }
        public int GaustNo { get; set; }
        public int RoomRefID { get; set; }
        [ForeignKey(nameof(RoomRefID))]
        public Room room { get; set; } = null!;

        public string Address { get; set; } = null!;
        public int StaterefID { get; set; }
        [ForeignKey(nameof(StaterefID))]
        public State? state { get; set; }
        public int CountryRefID { get; set; }
        [ForeignKey(nameof(CountryRefID))]
        public Country? country { get; set; }
        public string Landmark { get; set; } = null!;
        public int Pincode { get; set; }
        public string City { get; set; } = null!;


    }
}
