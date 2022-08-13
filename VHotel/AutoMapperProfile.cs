﻿using AutoMapper;
using staticclassmodel.DataAccess.Model.Master;
using staticclassmodel.DataAccess.Model.TransactionData;
using VHotel.DataAccess.DTo;
using VHotel.DataAccess.Model.TransactionData;

namespace VHotel
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Amenities, AmenuitiesDTO>().ReverseMap();
            CreateMap<HotelAmenitiesLink, HotelAmenitiesLinkDTO>().ReverseMap();
            CreateMap<AirlineDetails, AirlineDetailsDTO>().ReverseMap();
            CreateMap<Customer, CustomersDTO>().ReverseMap();
            CreateMap<FlightSchedule, FlightScheduleDTO>()
                                .ForMember(evw => evw.FlightName, opt => opt.MapFrom(em => em.flight.airlineDetails.AirlineName))
                                .ForMember(evw => evw.Flightlogo, opt => opt.MapFrom(em => em.flight.airlineDetails.AirlineLogo))

                .ReverseMap().ForPath(em => em.flight.airlineDetails.AirlineName, opt => opt.Ignore())
                .ForPath(em => em.flight.airlineDetails.AirlineLogo, opt => opt.Ignore())
             
            ;


            CreateMap<State, DropDownViewModel>()
                .ForMember(evw => evw.Text, opt => opt.MapFrom(em => em.StateName))

                .ReverseMap().ForPath(em => em.StateName, opt => opt.Ignore()); ;

            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Airport, AirportDTO>().ReverseMap();
            CreateMap<Flight, FlightDTO>().ReverseMap();
            CreateMap<FlightBooking, FlightBookingDTO>().ReverseMap();
            CreateMap<FlightBooking, FlightBookingDTO>().ReverseMap();
            CreateMap<HotelBooking, HotelBookingDTO>().ReverseMap();
            CreateMap<HotelCustomerDetail, HotelCustomerDetailDTO>().ReverseMap();

            CreateMap<Customerinformation, CustomerinformationDTO>().ReverseMap();



            CreateMap<State, StateDTO>().ReverseMap()

                         .ForPath(em => em.Countryref, opt => opt.Ignore());



            CreateMap<CityMaster, CityMasterdto>()
                 .ForMember(evw => evw.stateName, opt => opt.MapFrom(em => em.State.StateName))

                            .ReverseMap()
            .ForPath(em => em.State.StateName, opt => opt.Ignore());


        }
    }

}

