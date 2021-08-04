using AutoMapper;
using System;

namespace BLL.Mappers
{
    internal static class MappingConfiguration
    {
        public static Action<IMapperConfigurationExpression> Configure = (cfg) =>
        {
            cfg.AddProfile(new ProductProfile());            
        };
    }
}