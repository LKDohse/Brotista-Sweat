using AutoMapper;
using BTS.API.Maps;

namespace BTS.API
{
    public class AutoMapperConfig
    {
        public static void RegisterAutoMapperProfiles() {

            Mapper.Initialize(c =>
            c.AddProfile<ClassesMapper>()
            );
            Mapper.Configuration.CompileMappings(); 

            Mapper.AssertConfigurationIsValid();
        }
    }
}
