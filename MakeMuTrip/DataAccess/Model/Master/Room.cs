using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace staticclassmodel.DataAccess.Model.Masters
{
    [Table("RoomDetails", Schema = "RoomDetails")]
    [Index(nameof(RoomNumber), IsUnique = true)]
    public class Room : DataModelBase
    {
      
        public string RoomNumber { get; set; } = null!;
        public int RoomTypeRefID { get; set; }
        [ForeignKey(nameof(RoomTypeRefID))]
        public Type type { get; set; } = null!;
        public byte[]? RoomImage { get; set; } = null!;
        public int? HotelRefID { get; set; }
        [ForeignKey(nameof(HotelRefID))]
        public Hotel Hotel { get; set; }
        public int RoomLevel { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal RoomPrice { get; set; }
        public string Description { get; set; } = null!;

    }
}
