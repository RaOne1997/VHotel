using staticclassmodel.DataAccess.Model.Master;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace staticclassmodel.DataAccess.Model.TransactionData
{
    [Table(nameof(HotelBooking), Schema = "HotelTransactionData")]
    public class HotelBooking
    {
        [Key]
        public int Id { get; set; }
        public int HotelRefId { get; set; }
        [ForeignKey(nameof(HotelRefId))]
        public Hotel hotel { get; set; } = null!;
        public int ConfirmationCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        //public List<HotelCustomerDetail> HotelCustomerDetails { get; set; }=null!;
    }

}

