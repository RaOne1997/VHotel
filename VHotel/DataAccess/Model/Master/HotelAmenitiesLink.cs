using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace staticclassmodel.DataAccess.Model.Master
{
    [Table("HotelAmenitiesLink", Schema = "Hotel")]
    public class HotelAmenitiesLink : DataModelBase
    {
     
        public int HotelRefId { get; set; }
        [ForeignKey(nameof(HotelRefId))]
        public Hotel hotel { get; set; } = null!;
        [Required]
        public int AmenitiesRefId { get; set; }
        [ForeignKey(nameof(AmenitiesRefId))]
        public Amenities AmenitiesRef { get; set; }= null!;
    }
}
