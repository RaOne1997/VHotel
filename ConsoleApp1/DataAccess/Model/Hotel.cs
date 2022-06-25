using System.ComponentModel.DataAnnotations.Schema;

namespace VHotel.DataAccess.Model
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int HotelId { get; set; }
        public string Address { get; set; } = null!;
        public int StaterefID { get; set; }
        [ForeignKey(nameof(StaterefID))]
        public State state { get; set; }=null!;
        public int CountryRefID { get; set; }
        [ForeignKey(nameof(CountryRefID))]
        public Country country { get; set; }=null!;
        public string Landmark { get; set; } = null!;
        public int Pincode { get; set; }
        public string City { get; set; } = null!;

        
    }
}
