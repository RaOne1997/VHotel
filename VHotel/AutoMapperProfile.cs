using AutoMapper;
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


            CreateMap<FlightBooking, FlightBookingInputDTO>().ReverseMap();
            CreateMap<FlightBooking, FlightBookingInputDTO>().ReverseMap();

            CreateMap<FlightBooking, FlightBookingDTO>()

                      .ForMember(evw => evw.FlightCode, opt => opt.MapFrom(em => em.flightSchedule.flight.FlightCode))
                                .ForMember(evw => evw.Fromairport, opt => opt.MapFrom(em => em.flightSchedule.flight.airportFrom.AirportName))
                                .ForMember(evw => evw.FromAirportCode, opt => opt.MapFrom(em => em.flightSchedule.flight.airportFrom.AirportCode))
                                .ForMember(evw => evw.Toairport, opt => opt.MapFrom(em => em.flightSchedule.flight.airportToAirport.AirportName))
                                .ForMember(evw => evw.toAirportCode, opt => opt.MapFrom(em => em.flightSchedule.flight.airportToAirport.AirportCode))
                                .ForMember(evw => evw.ArrivalDate, opt => opt.MapFrom(em => em.flightSchedule.ArrivalDate))
                                .ForMember(evw => evw.DepartureDate, opt => opt.MapFrom(em => em.flightSchedule.DepartureDate))


                .ReverseMap()
                                .ForPath(em => em.flightSchedule.flight.airportFrom.AirportName, opt => opt.Ignore())
                                .ForPath(em => em.flightSchedule.flight.airportFrom.AirportCode, opt => opt.Ignore())
                                .ForPath(em => em.flightSchedule.flight.airportToAirport.AirportName, opt => opt.Ignore())
                                .ForPath(em => em.flightSchedule.flight.airportToAirport.AirportCode, opt => opt.Ignore())
                                .ForPath(em => em.flightSchedule.ArrivalDate, opt => opt.Ignore())
                                .ForPath(em => em.flightSchedule.DepartureDate, opt => opt.Ignore())

                .ForPath(em => em.flightSchedule.flight.FlightCode, opt => opt.Ignore());


            CreateMap<FlightSchedule, BookingFlightDTO>()

                      .ForMember(evw => evw.FlightCode, opt => opt.MapFrom(em => em.flight.FlightCode))
                      .ForMember(evw => evw.FlightScheduleRefId, opt => opt.MapFrom(em => em.ID))
                                .ForMember(evw => evw.Fromairport, opt => opt.MapFrom(em => em.flight.airportFrom.AirportName))
                                .ForMember(evw => evw.FromAirportCode, opt => opt.MapFrom(em => em.flight.airportFrom.AirportCode))
                                .ForMember(evw => evw.Toairport, opt => opt.MapFrom(em => em.flight.airportToAirport.AirportName))
                                .ForMember(evw => evw.toAirportCode, opt => opt.MapFrom(em => em.flight.airportToAirport.AirportCode))
                                .ForMember(evw => evw.ArrivalDate, opt => opt.MapFrom(em => em.ArrivalDate))
                                .ForMember(evw => evw.DepartureDate, opt => opt.MapFrom(em => em.DepartureDate))


                .ReverseMap()
                                .ForPath(em => em.flight.airportFrom.AirportName, opt => opt.Ignore())
                                .ForPath(em => em.flight.airportFrom.AirportCode, opt => opt.Ignore())
                                .ForPath(em => em.flight.airportToAirport.AirportName, opt => opt.Ignore())
                                .ForPath(em => em.flight.airportToAirport.AirportCode, opt => opt.Ignore())
                                .ForPath(em => em.ArrivalDate, opt => opt.Ignore())
                                .ForPath(em => em.DepartureDate, opt => opt.Ignore())
                                .ForPath(em => em.flight.FlightCode, opt => opt.Ignore())
                                .ForPath(em => em.ID, opt => opt.Ignore());


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

