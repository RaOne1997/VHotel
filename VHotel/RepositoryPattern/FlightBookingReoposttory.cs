﻿using AutoMapper;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using staticclassmodel.DataAccess.Model.Master;
using staticclassmodel.DataAccess.Model.TransactionData;
using VHotel.DataAccess;
using VHotel.DataAccess.DTo;
using VHotel.RepositoryPattern.Interface;

namespace VHotel.RepositoryPattern
{
    public class FlightBookingReoposttory : Repository<FlightBooking>, IFlightBookingReoposttory
    {
        private readonly VhotelsSQLContex _db;
        private readonly IMapper _mapper;

        public FlightBookingReoposttory(VhotelsSQLContex db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<FlightBooking> GetbyFlightID(int ID)
        {
            var flightBookingDTOsres = _db.flightBookings.Include(p=>p.FlightCustomerDetails).Where(m => m.FlightScheduleRefId == ID);
            return  await flightBookingDTOsres.FirstOrDefaultAsync();
        }
    }
}
