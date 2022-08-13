﻿using EmployeeCrud.RepositoryPattern.RepositoryBase;
using staticclassmodel.DataAccess.Model.TransactionData;
using VHotel.DataAccess.DTo;

namespace VHotel.RepositoryPattern.Interface
{
    public interface IFlightBookingReoposttory : IRepository<FlightBooking>
    {
        public Task<FlightBooking> GetbyFlightID(int ID);
    }
}
