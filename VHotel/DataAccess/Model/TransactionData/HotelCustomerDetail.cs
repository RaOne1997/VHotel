using staticclassmodel.DataAccess.Model.Master;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace staticclassmodel.DataAccess.Model.TransactionData
{
    [Table(nameof(HotelCustomerDetail), Schema = "TransactionData")]
    public class HotelCustomerDetail
    {
        [Key]
        public int Id { get; set; }
        public int HotelBookingRefId { get; set; }
        [ForeignKey(nameof(HotelBookingRefId))]
        HotelBooking hotelBooking { get; set; } = null!;
        public int CustomerRefId { get; set; }
        [ForeignKey(nameof(CustomerRefId))]
        public Customer customer { get; set; } = null!;
    }
}