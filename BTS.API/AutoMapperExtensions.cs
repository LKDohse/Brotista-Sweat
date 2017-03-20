using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper; 

namespace BTS.API
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);
            var existingMaps = Mapper.Configuration.GetAllTypeMaps()
                .FirstOrDefault(x => x.SourceType.Equals(sourceType) && x.DestinationType.Equals(destinationType));
            if (existingMaps != null)
            {
                foreach (var property in existingMaps.GetUnmappedPropertyNames())
                {
                    expression.ForMember(property, opt => opt.Ignore());
                }
            }
            return expression;
        }
    }
}
