using AutoMapper;
using staticclassmodel.DataAccess.Model.Master;
using VHotel.DataAccess.DTo;

namespace VHotel
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<State, StateDTO>().ReverseMap()

                         .ForPath(em => em.Countryref, opt => opt.Ignore()); 



            CreateMap<CityMaster, CityMasterdto>()
                 .ForMember(evw => evw.stateName, opt => opt.MapFrom(em => em.State.StateName))
  
                            .ReverseMap()
            .ForPath(em => em.State.StateName, opt => opt.Ignore());

            
        }
    }

}

                                                                                