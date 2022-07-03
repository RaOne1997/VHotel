﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace staticclassmodel.DataAccess.Model.Master
{
    [Table("Hotel", Schema = "Hotels")]
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int HotelId { get; set; }
        public byte[]? HotelImage { get; set; }
        public int HotelRating { get; set; }
        public DateTime checkout { get; set; }
        public DateTime checkin { get; set; }
        public int GaustNo { get; set; }
        public int RoomtypeRef { get; set; }
        [ForeignKey(nameof(RoomtypeRef))]
        public Type type { get; set; } = null!;

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