using AutoMapper;
using staticclassmodel.DataAccess.Model.Master;
using VHotel.DataAccess.DTo;

namespace VHotel
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<CityMaster, CityMasterdto>().ReverseMap();

            //CreateMap<Employee, EmployeeViewModel>()
            //    .ForMember(evw => evw.DepartmentName, opt => opt.MapFrom(em => em.DepartmentRef.Name))
            //    .ForMember(evw => evw.NationalityText, opt => opt.MapFrom(em => em.NationalityRef.Text))
            //    .ReverseMap()
            //    .ForPath(em => em.DepartmentRef.Name, opt => opt.Ignore())
            //    .ForPath(em => em.NationalityRef.Text, opt => opt.Ignore());
        }
    }

}

