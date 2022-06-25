﻿using Microsoft.EntityFrameworkCore;
using VHotel.DataAccess.Model;

namespace VHotel.DataAccess
{
    public class VhotelsSQLContex : DbContext
    {

        public VhotelsSQLContex()
        {
        }

        public DbSet<Country> countries { get; set; } = null!;
        public DbSet<Hotel>hotels{get;set;}=null!;
        public DbSet<Room> rooms{get;set;}=null!;
        public DbSet<State> states{get;set;}=null!;
        public DbSet<Type> types {get;set;}=null!;
   
        public VhotelsSQLContex(DbContextOptions<VhotelsSQLContex> options)
            : base(options)
        {
        }
    }
}