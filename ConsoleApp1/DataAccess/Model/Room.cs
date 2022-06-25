using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VHotel.DataAccess.Model
{
    [Table("RoomDetails", Schema = "RoomDetails")]
    [Index(nameof(RoomNumber), IsUnique = true)]
    public class Room
    {
        public int ID { get; set; }
        public string RoomNumber { get; set; } = null!;
        public int RoomTypeRefID { get; set; } 
        public byte[] RoomImage { get; set; } = null!;
        public int RoomLevel { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal RoomPrice { get; set; }
        public string Description { get; set; } = null!;

    }
}
