using AutoMapper;
using BTS.API.Models;
using ClassService; 

namespace BTS.API.Maps
{
    public class ClassesMapper : Profile
    {
        public ClassesMapper()
        {
            CreateMap<ClassService.Class, Models.ClassApiModel>(MemberList.None)
                .ForMember(c => c.ClassScheduleID, config => config.MapFrom(c => c.ClassScheduleID))
                .ForMember(c => c.ClassDescription, config => config.MapFrom(d => d.ClassDescription));

            CreateMap<ClassService.ClassDescription, Models.ClassDescriptionApiModel>(MemberList.None);
        }
    }
}
