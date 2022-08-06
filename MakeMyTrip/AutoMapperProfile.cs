using AutoMapper;
using MakeMyTrip.Data;
using MakeMyTrip.Data.DTO;

namespace MakeMyTrip
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Books, BooksDTO>().ReverseMap();
            CreateMap<Bookdetals, BookDetailsDTO>()


                .ForMember(evw => evw.authors, opt => opt.MapFrom(em => em.authorss.AutherName))
                .ForMember(evw => evw.price, opt => opt.MapFrom(em => em.Books.price))
                .ForMember(evw => evw.image, opt => opt.MapFrom(em => em.Books.image))
                .ForMember(evw => evw.title, opt => opt.MapFrom(em => em.Books.title))


                .ReverseMap().ForPath(em => em.authorss.AutherName, opt => opt.Ignore());
               
        }
    }
}
